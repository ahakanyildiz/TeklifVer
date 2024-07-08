using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Common.Enums;
using TeklifVer.Common.Helpers;
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


        [Route("Panel/Login")]
        [HttpGet]
        public IActionResult SignIn()
        {
            //_memberService.CreateUserAndRoles();
            ViewBag.CustomCss = "Member/SignIn.css";
            return View(new MemberLoginDto());
        }

        [Route("Panel/Login")]
        [HttpPost]
        public async Task<IActionResult> SignIn(MemberLoginDto memberLoginDto)
        {
            if (memberLoginDto == null)
            {
                ModelState.AddModelError("Error", "Eposta veya şifre girmediniz");
                return View(new MemberLoginDto());
            }

            var result = _memberService.AuthenticateUser(memberLoginDto);
            if (result.IsSuccess && result.Data.RoleId == (int)RoleType.Admin)
            {
                var claims = new List<Claim> {


                    new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Email, memberLoginDto.Email),
                    new Claim(ClaimTypes.Role, result.Data.RoleId == (int)RoleType.Admin ? "admin" : "member")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Error", result.ErrorMessage);
            return View(memberLoginDto);
        }

        public async Task<IActionResult> SignOut()
        {

            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["isSuccess"] = "İşlem Başarılı";
            }

            return RedirectToAction("Index", "Main");
        }


        public IActionResult SignUp()
        {
            return View(new MemberSignUpDto());
        }

        [HttpPost]

        public IActionResult SignUp(MemberSignUpDto memberSignUpDto)
        {
            var result = _memberService.Create(memberSignUpDto);
            TempData["isOkey"] = result.IsSuccess ? "Okey" : "No";
            TempData["message"] = result.IsSuccess ? "Kayıt başarıyla yapıldı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("GirisYap", "Login") : View(memberSignUpDto);
        }

        [HttpGet]
        public async Task<IActionResult> GirisYap()
        {
            ViewBag.CustomCss = "Login/GirisYap.css";
            return View(new MemberLoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(MemberLoginDto memberLoginDto)
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
                {     new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Email, result.Data.Email),
                    new Claim(ClaimTypes.Role, result.Data.RoleId == (int)RoleType.Admin ? "admin" : "member")
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Main");
        }
    }
}

