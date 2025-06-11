using DicaVerde.Context;
using DicaVerde.Models;
using DicaVerde.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DicaVerde.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;

    public AccountController(UserManager<User> userManager,
        SignInManager<User> signInManager,
        AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVM)
    {
        if (!ModelState.IsValid)
            return View(loginVM);

        var user = await _userManager.FindByNameAsync(loginVM.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, 
                loginVM.Password, false, false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginVM.ReturnUrl);
            }
        }
        ModelState.AddModelError("", "Falha ao realizar o login!!");
        return View(loginVM);
    }//

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registroVM)

    {
        if (ModelState.IsValid)
        {
            var identityUser = new User { UserName = registroVM.UserName, NomeCompleto = registroVM.UserName, Perfil = "MEMBER" };
            var result = await _userManager.CreateAsync(identityUser, registroVM.Password);

            if (result.Succeeded)
            {
                // Criar também o usuário na sua tabela local
                var user = new User
                {
                    NomeCompleto = registroVM.UserName, // ou outro campo
                    Email = identityUser.UserName,
                    Perfil = "MEMBER"
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(identityUser, "Member");
                return RedirectToAction("Login", "Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
            }
        }
        return View(registroVM);
    }


    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
