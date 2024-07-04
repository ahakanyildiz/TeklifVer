using DataAccess.Contexts;
using Entities;
using System.Linq.Expressions;
using TeklifVer.DataAccess.Abstract;

namespace TeklifVer.DataAccess.Concrete
{
    public class MemberRepository : IMemberRepository
    {
        private readonly CarContext _context;

        public MemberRepository(CarContext context)
        {
            _context = context;
        }

        public async Task Create(Member member)
        {
            await _context.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public Member GetByFilter(Expression<Func<Member, bool>> filter) => _context.Members.SingleOrDefault(filter);
    }
}
