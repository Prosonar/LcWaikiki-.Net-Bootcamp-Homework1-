using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatingWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Şükrü",
                LastName = "Sonar",
                Email = "asd@gmail.com",
                BirthDate = new DateTime(1999,8,1)
            },
            new User()
            {
                Id = 2,
                FirstName = "Bayram",
                LastName = "Sonar",
                Email = "asd123@gmail.com",
                BirthDate = new DateTime(2000,8,1)
            },
            new User()
            {
                Id = 3,
                FirstName = "Adem",
                LastName = "Sonar",
                Email = "asd789@gmail.com",
                BirthDate = new DateTime(2002,8,1)
            },
            new User()
            {
                Id = 4,
                FirstName = "Musa",
                LastName = "Sonar",
                Email = "asd456@gmail.com",
                BirthDate = new DateTime(2005,8,1)
            },
            new User()
            {
                Id = 5,
                FirstName = "Özlem",
                LastName = "Sonar",
                Email = "asd159@gmail.com",
                BirthDate = new DateTime(2008,8,1)
            },
            new User()
            {
                Id = 6,
                FirstName = "Elif",
                LastName = "Sonar",
                Email = "asd753@gmail.com",
                BirthDate = new DateTime(2012,8,1)
            },
        };

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                return BadRequest("Kullanıcı id bulunamadı. İşlem başarısız.");
            }
            return Ok(user);
        }


        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            User user = users.SingleOrDefault(x => x.Email == email);
            if(user == null)
            {
                return BadRequest("Bu eposta adresiyle kayıtlı kullanıcı yok.");
            }
            return Ok(user);
        }

        [HttpGet("lastname/{lastName}")]
        public IActionResult GetUsersByLastName(string lastName)
        {
            List<User> result = users.FindAll(x => x.LastName.ToLower().Contains(lastName.ToLower()));
            if (result.Count == 0)
            {
                return Ok("Kullanıcı bulunamadı.");
            }
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetUsersByName(string name)
        {
            List<User> result = users.FindAll(x => x.FirstName.ToLower().Contains(name.ToLower()));
            if (result.Count == 0)
            {
                return Ok("Kullanıcı bulunamadı.");
            }
            return Ok(result);
        }

        [HttpGet]
        public ActionResult Users()
        {
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromForm] User user)
        {
            User result = users.SingleOrDefault(x => x.Id == user.Id);
            if(result != null)
            {
                return BadRequest("Kullanıcı id mevcut.İşlem başarısız.");
            }
            users.Add(user);
            return Ok("İşlem başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromForm] User user)
        {
            User result = users.SingleOrDefault(x => x.Id == user.Id);
            if(result == null)
            {
                return BadRequest("Kullanıcı id bulunamadı.İşlem başarısız.");
            }
            users.Find(x => x.Id == user.Id).FirstName = user.FirstName;
            users.Find(x => x.Id == user.Id).LastName = user.LastName;
            users.Find(x => x.Id == user.Id).Email = user.Email;
            users.Find(x => x.Id == user.Id).BirthDate = user.BirthDate;
            return Ok("İşlem başarılı.");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                return BadRequest("Kullanıcı id bulunamadı. İşlem başarısız.");
            }
            users.Remove(user);
            return Ok("İşlem başarılı.");
        }
    }
}
