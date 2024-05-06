using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;
using rfm.srv.kitdevnet.output.sqlserver.ef.commons;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Entity;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Mapper;

namespace rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository
{
    internal class ItemEFRepository
    {
        private readonly ItemEntityMapper _itemEntityMapper;
        private readonly EFSqlServerContext _context;

        internal ItemEFRepository(EFSqlServerContext context)
        {
            _itemEntityMapper = new();
            _context = context;
        }

        internal async Task<int> Atualizar(int id, ItemCriarModel model)
        {
            var ent = await _itemEntityMapper.toEntidade(model);
            ent.Id = id;
            _context.Itens.Update(ent);
            _context.SaveChanges();

            return id;
        }

        internal async Task<int> Criar(ItemCriarModel model)
        {
            var ent = await _itemEntityMapper.toEntidade(model);
            _context.Itens.Add(ent);
            _context.SaveChanges();

            return ent.Id;
        }

        internal async Task Excluir(int id)
        {
            _context.Remove(new ItemEntity() { Id = id });
            _context.SaveChanges();
        }

        internal async Task<ResultadoPaginado<ItemModel>> ListarPaginado(BaseFiltro filtro)
        {
            var total = _context.Itens.Count();
            var ents = _context.Itens
                .OrderBy(b => b.Id)
                .Skip(filtro.Pagina * filtro.Tamanho)
                .Take(filtro.Tamanho)
                .ToList();

            var lst = new List<ItemModel>();
            foreach (var ent in ents)
            {
                var model = await _itemEntityMapper.toModel(ent);
                lst.Add(model);
            }

            var result = new ResultadoPaginado<ItemModel>()
            {
                Itens = lst,
                Tamanho = filtro.Tamanho,
                Pagina = filtro.Pagina,
                TotalRegistros = total,
            };

            return result;
        }

        internal async Task<ItemModel> Obter(int id)
        {
            var ent = _context.Itens.SingleOrDefault(x => x.Id == id);
            var model = await _itemEntityMapper.toModel(ent);
            return model;
        }
    }
}
