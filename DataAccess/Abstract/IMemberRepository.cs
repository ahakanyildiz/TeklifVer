using Entities;
using System.Linq.Expressions;

namespace TeklifVer.DataAccess.Abstract
{
    public interface IMemberRepository
    {
        public Task Create(Member member);
        public Member GetByFilter(Expression<Func<Member, bool>> filter);

    }
}
