using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimCardManagement.Models;
using SimCardManagement.ModelView;

namespace SimCardManagement.Controllers.Admin
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.roles = _roleManager.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountModelView mv)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(mv.Photo.FileName);
                string imageName = mv.Photo.FileName + Guid.NewGuid() + extension;
                if (mv.Photo != null)
                {
                    string path = Path.Combine(Path.Combine(_hostingEnvironment.WebRootPath, "UserImages"), imageName);
                    mv.Photo.CopyTo(new FileStream(path, FileMode.Create));
                }


                var user = new ApplicationUser { UserName = mv.Email ,Email = mv.Email ,Name = mv.Name ,Photo = imageName ,PhoneNumber = mv.PhoneNumber , AccountType = mv.AccountType , Location = mv.Location , IdCardNumber = mv.IdCardNumber , WorkPostion = mv.WorkPostion};
                var result = await _userManager.CreateAsync(user, mv.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, mv.Role);
                    ModelState.Clear();
                    ViewBag.alertMsg = "تمت ألعملية بنجاح";
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.roles = _roleManager.Roles;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModelsView vm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email,
                   vm.Password, vm.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "ألحساب معلق");
                }
            }
            ModelState.AddModelError("", "خطأ في ألبريد الألكتروني أو ألرقم ألسري");
            return View();
        }
        public async Task Delete(string id)
        {
            var user = _userManager.Users.SingleOrDefault(s=>s.Id.Equals(id));
            await _userManager.DeleteAsync(user);
        }
        [HttpGet]
        public IActionResult EditPassword(string id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPassword(ChangePasswordModelView mv,string id)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.SingleOrDefault(s => s.Id.Equals(id));
                if (user == null)
                {
                    return RedirectToAction(nameof(Login));
                }
                var result = await _userManager.ChangePasswordAsync(user, mv.CurrentPassword, mv.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                ViewBag.alertMsg = "تمت ألعملية بنجاح";
                return View();
            }
            return View();
        }
    }
}