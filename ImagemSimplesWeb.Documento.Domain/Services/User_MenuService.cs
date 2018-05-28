using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Services
{
    public class User_MenuService : IUser_MenuService
    {
        private readonly IUser_MenuRepository _menurepository;
        private readonly IUser_Cat_AtributoRepository _atribrepository;
        private readonly IUser_Tipo_ArquivoRepository _tipoarquivorepository;
        private readonly IUser_Documento_ImagemRepository _documentorepository;
        public User_MenuService(IUser_MenuRepository menurepository, IUser_Cat_AtributoRepository atribrepository,
            IUser_Tipo_ArquivoRepository tipoarquivorepository, IUser_Documento_ImagemRepository documentorepository)
        {
            _menurepository = menurepository;
            _atribrepository = atribrepository;
            _tipoarquivorepository = tipoarquivorepository;
            _documentorepository = documentorepository;
        }

        public void AlteraCategoria(user_menu1 cat, List<user_cat_atributos> atrib)
        {
            int i = 1;
            var cat1 = _menurepository.ObterPorId(cat.id_oper);
            cat1.dependencia = cat.dependencia;
            cat1.descricao = cat.descricao;
            cat1.nivel = cat.nivel;
            cat1.nome = cat.nome;
            cat1.existemdb = cat.existemdb;
            cat1.pathimagens = cat.pathimagens;
            cat1.id_tipo_arquivo = cat.id_tipo_arquivo;
            _menurepository.Atualizar(cat1);

            var at = _documentorepository.Buscar(x => x.id_categoria == cat1.id_oper).ToList();
            if (at.Count == 0)
            {
                _atribrepository.ExcluirAtributos(cat1.id_oper);
                foreach (var item in atrib)
                {
                    item.ordem = i;
                    _atribrepository.Adicionar(item);
                    i = i + 1;
                }
            }
        }

        public void AlteraCategoria(user_menu1 cat)
        {
            _menurepository.Adicionar(cat);
        }

        public user_menu1 BuscaCategoria(int id)
        {
            var cat = _menurepository.ObterPorId(id);
            //cat.Atributos = _atribrepository.Buscar(x => x.id_Oper == cat.id_Oper).ToList();
            return cat;
        }

        public List<user_menu1> CategoriasDocumento()
        {
            return _menurepository.CategoriasDocumento();
        }

        public void ExcluiAtributos(user_menu1 cat)
        {
            _atribrepository.ExcluirAtributos(cat.id_oper);
        }

        public void InsereCategoria(user_menu1 cat, List<user_cat_atributos> atrib)
        {
            int i = 1;
            var cat2 = _menurepository.Adicionar(cat);
            foreach (var item in atrib)
            {
                item.ordem = i;
                item.id_oper = cat2.id_oper;
                _atribrepository.Adicionar(item);
                i = i + 1;
            }
        }

        public List<user_menu1> ListaCategorias()
        {
            return _menurepository.ObterTodos().ToList();
        }

        public List<user_tipo_arquivo> ListaTiposArquivo()
        {
            return _tipoarquivorepository.ObterTodos().ToList();
        }

        public List<user_cat_atributos> RetornaAtributos(int id_Oper)
        {
            return _atribrepository.Buscar(x => x.id_oper == id_Oper).ToList();
        }
   
        public List<user_menu1> RetornaCategorias(DTOCategorias filtro)
        {
           return _menurepository.RetornaCategorias(filtro);
            //return _menurepository.Buscar(x => x.descricao.Contains(desc)).ToList();
        }

        public string ValidaCategoria(user_menu1 cat)
        {
            if (cat.id_tipo_arquivo == 1 && String.IsNullOrEmpty(cat.pathimagens))
            {
                return "Por favor informe o caminho dos arquivos .MDB";
            }
            if (cat.id_tipo_arquivo == 2 && String.IsNullOrEmpty(cat.pathimagens))
            {
                return "Por favor informe o caminho dos arquivos .XML";
            }
            return "";
        }

        public string VerificaDocumentosVinculados(int id_Oper)
        {
            var docs = _documentorepository.Buscar(x => x.id_categoria == id_Oper).ToList();
            if (docs.Count > 0)
            {
                return "Não será possível alterar esta categoria pois ela já possui documentos vinculados.";
            }
            return "";
        }
    }
}
