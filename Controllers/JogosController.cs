using Microsoft.AspNetCore.Mvc;

namespace First_API;
[ApiController]
[Route("Jogos")]
public class JogosController : ControllerBase
{

private static List<Jogo> jogos = new List<Jogo>();
    //Metodo Get
    [HttpGet]
    public List<Jogo> Get()
    {
        return jogos;
    }
    //Metodo Status
    [HttpGet("status")]
    public string Status()
    {
        return "API Funcionando";
    }

    //Metodo Get por ID
    [HttpGet("{id:int}")]
    public IActionResult GetPorId(int id)
    {
        foreach (Jogo jogo in jogos)
        {
            if (jogo.Id == id)
            {
                return Ok(jogo);
            }
        }
        return NotFound("Jogo não encontrado.");
    }

    //Metodo Post
    [HttpPost]
    public IActionResult Post([FromBody]Jogo jogo)
    {
        //Validações ID
        if (jogo.Id <= 0)
        {
            return BadRequest("O ID do jogo deve ser maior que zero.");
        }
        //Validações Nome
        if (string.IsNullOrWhiteSpace(jogo.Nome))
        {
            return BadRequest("O nome do jogo e obrigatorio.");
        }
        //Validações Genero
        if (string.IsNullOrWhiteSpace(jogo.Genero))
        {
            return BadRequest("O genero do jogo e obrigatorio.");
        }
        //Validações de ID duplicado
        foreach (Jogo jogoExistente in jogos)
        {
            if (jogoExistente.Id == jogo.Id)
            {
                return Conflict("Ja existe um jogo com esse ID.");
            }
        }

        jogos.Add(jogo);
        return Ok(jogo);

    }
}