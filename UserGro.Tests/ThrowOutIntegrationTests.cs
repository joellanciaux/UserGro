using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UserGro.Model;

namespace UserGro.Tests
{
    public class ContextCreate : RecreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            
        }
    }
    [TestFixture]
    class ThrowOutIntegrationTests
    {
        public ThrowOutIntegrationTests()
        {
            Database.SetInitializer<Context>(new ContextCreate());
        }

        //this is just a test for entity framework how it handles interfaces rather than concrete items...
        [Test]
        public void i_can_set_user_to_groups_and_both_get_persisted()
        {
            var user = new User();
            var group = new Group();

            user.Email = "test@somesite.com";
            user.UserName = "testguy" + Guid.NewGuid().ToString();
            user.Name = "Tester Guy";

            group.Id = Guid.NewGuid().ToString();
            group.Name = "Awesome Group";
            group.Users.Add(user);
            user.Groups.Add(group);

            var ctx = new Context();
            ctx.Groups.Add(group);
            ctx.SaveChanges();

            var q = ctx.Groups;
            
            Assert.That(q.Count() > 0);
            Assert.That(q.First().Users.Count > 0);
        }
            
    }
}
