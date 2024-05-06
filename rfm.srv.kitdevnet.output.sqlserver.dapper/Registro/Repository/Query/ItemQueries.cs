namespace rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Query
{
    internal class ItemQueries
    {
        internal const string CRIAR =
            @"
                 insert into tb_produto
                     (descricao, quantidade, precoUnitario, ativo, dataCriacao)
                 values
                     (@descricao, @quantidade, @precoUnitario, @ativo, @dataCriacao);

                 select CAST(SCOPE_IDENTITY() as int);
            ";

        internal const string EXCLUIR =
            @"
                delete from tb_produto
                where id = @id
            ";

        internal const string OBTER =
            @"
                select
	                prd.id as Id,
	                prd.descricao as Descricao,
	                prd.quantidade as Quantidade,
	                prd.precoUnitario as PrecoUnitario,
	                prd.ativo as Ativo,
	                prd.dataCriacao as DataCriacao
                from tb_produto prd
                where prd.id = @id;
            ";

        internal const string ATUALIZAR =
            @"
                update tb_produto
                    set descricao = @descricao,
                        quantidade = @quantidade,
                        precoUnitario = @precoUnitario,
                        ativo = @ativo,
                        dataCriacao = @dataCriacao
                where id = @id;
            ";

        internal const string COUNT =
            @"
                select count(*) as total
                from tb_produto prd;
            ";

        internal const string LISTAR_PAGINADO =
            @"
                select
                    prd.id as Id,
                    prd.descricao as Descricao,
                    prd.quantidade as Quantidade,
                    prd.precoUnitario as PrecoUnitario,
                    prd.ativo as Ativo,
                    prd.dataCriacao as DataCriacao
                from tb_produto prd
                order by prd.id
                OFFSET (@pagina * @tamanho) ROWS
                FETCH NEXT @tamanho ROWS ONLY;
            ";
    }
}
