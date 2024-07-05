using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Common.Enums;
using TeklifVer.Dto.Member;

namespace TeklifVer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemberService _memberService;

        public LoginController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new MemberLoginDto());
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> SignIn(MemberLoginDto memberLoginDto)
        {
            if (memberLoginDto == null)
            {
                ModelState.AddModelError("Error", "Eposta veya şifre girmediniz");
                return View(new MemberLoginDto());
            }

            var result = _memberService.AuthenticateUser(memberLoginDto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Error", result.ErrorMessage);
                return View(memberLoginDto);
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, memberLoginDto.Email),
                    new Claim(ClaimTypes.Role, result.Data.RoleId == (int)RoleType.Admin ? "admin" : "member")
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SignOut()
        {

            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["isSuccess"] = "İşlem Başarılı";
            }

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> SignUp()
        {
            return View(new MemberSignUpDto());
        }

        [HttpPost]

        public async Task<IActionResult> SignUp(MemberSignUpDto memberSignUpDto)
        {
            var result = _memberService.Create(memberSignUpDto);
            TempData["isSuccess"] = result.IsSuccess ? "Kayıt başarıyla oluşturuldu" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index", "Home") : View(memberSignUpDto);
        }
    }
}

