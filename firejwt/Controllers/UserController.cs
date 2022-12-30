using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly FirebaseAuth _auth;

    public UserController(FirebaseAuth auth)
    {
        _auth = auth;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        // Authenticate the user
        UserRecord userRecord = await _auth.SignInWithEmailAndPasswordAsync(email, password);

        // Get the JWT token
        string jwt = userRecord.CustomClaims["jwt"];

        // Return the JWT token to the client
        return Ok(new { token = jwt });
    }
}