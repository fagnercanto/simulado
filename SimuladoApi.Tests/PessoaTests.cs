namespace SimuladoApi.Tests;
using Xunit;
public class PessoaTests
{
    [Fact]
    public void CriarPessoa_DeveRetornarObjetoComNome()
    {
        var pessoa = new Pessoa { Nome = "Fagner" };
        Assert.Equal("Fagner", pessoa.Nome);
    }
}
