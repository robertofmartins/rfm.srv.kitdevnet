﻿using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Produto;

namespace rfm.srv.kitdevnet.domain.interfaces.input
{
    public interface IProdutoUserCase
    {
        Task<int> Criar(ProdutoCriarModel model);

        Task<ProdutoModel> Obter(int id);

        Task<ResultadoPaginado<ProdutoModel>> ListarPaginado(BaseFiltro filtro);

        Task<int> Atualizar(int id, ProdutoCriarModel model);

        Task Excluir(int id);
    }
}
