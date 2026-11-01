using Microsoft.AspNetCore.Mvc;

namespace First_API;
[ApiController]
[Route("Jogos")]
public class JogosController : ControllerBase
{

private static List<Jogo> jogos = new List<Jogo>();

    [HttpGet]
    public List<Jogo> Get()
    {
        return jogos;
    }//Fecha Metodo Get

    [HttpGet("status")]
    public string Status()
    {
        return "API Funcionando";
    }//Fecha o metodo Status
    [HttpPost]
    public IActionResult Post([FromBody]Jogo jogo)
    {
        foreach (Jogo jogoExistente in jogos)
        {
            if (jogoExistente.Id == jogo.Id)
            {
                return Conflict("Ja existe um jogo com esse ID.");
            }
        }

        jogos.Add(jogo);
        return Ok(jogo);

    }//Fecha Metodo Post
}//Fecha a classe Jogos Controller