using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PushUpContext context;
        private ICategoriaPersona _categoriapersona;
        private ICiudad _ciudad;
        private IContactoPersona _contactopersona;
        private IContrato _contrato;
        private IDepartamento _departamento;
        private IDirPersona _dirpersona;
        private IEstado _estado;
        private IPais _pais;
        private IPersona _persona;
        private IProgramacion _programacion;
        private ITipoContacto _tipocontacto;
        private ITipoDireccion _tipodireccion;
        private ITipoPersona _tipopersona;
        private ITurno _turno;

        public UnitOfWork(PushUpContext _context)
        {
            context = _context;
        }

        public ICategoriaPersona CategoriaPersonas {
            get{
                if(_categoriapersona == null){
                    _categoriapersona = new CategoriaPersonaRepository(context);
                }
                return _categoriapersona;
            }
        }
        public ICiudad Ciudades {
            get{
                if(_ciudad == null){
                    _ciudad = new CiudadRepository(context);
                }
                return _ciudad;
            }
        }
              public IContactoPersona ContactoPersonas {
            get{
                if(_contactopersona == null){
                    _contactopersona = new ContactoPersonaRepository(context);
                }
                return _contactopersona;
            }
        }
              public IContrato Contratos {
            get{
                if(_contrato == null){
                    _contrato = new ContratoRepository(context);
                }
                return _contrato;
            }
        }
              public IDepartamento Departamentos {
            get{
                if(_departamento == null){
                    _departamento = new DepartamentoRepository(context);
                }
                return _departamento;
            }
        }
              public IDirPersona DirPersonas {
            get{
                if(_dirpersona == null){
                    _dirpersona = new DirPersonaRepository(context);
                }
                return _dirpersona;
            }
        }
              public IEstado Estados {
            get{
                if(_estado == null){
                    _estado = new EstadoRepository(context);
                }
                return _estado;
            }
        }
              public IPais Paises {
            get{
                if(_pais == null){
                    _pais = new PaisRepository(context);
                }
                return _pais;
            }
        }
              public IPersona Personas {
            get{
                if(_persona == null){
                    _persona = new PersonaRepository(context);
                }
                return _persona;
            }
        }
              public IProgramacion Programaciones {
            get{
                if(_programacion == null){
                    _programacion = new ProgramacionRepository(context);
                }
                return _programacion;
            }
        }
              public ITipoContacto TipoContactos {
            get{
                if(_tipocontacto == null){
                    _tipocontacto = new TipoContactoRepository(context);
                }
                return _tipocontacto;
            }
        }
              public ITipoDireccion TipoDirecciones {
            get{
                if(_tipodireccion == null){
                    _tipodireccion = new TipoDireccionRepository(context);
                }
                return _tipodireccion;
            }
        }
              public ITipoPersona TipoPersonas {
            get{
                if(_tipopersona == null){
                    _tipopersona = new TipoPersonaRepository(context);
                }
                return _tipopersona;
            }
        }
              public ITurno Turnos {
            get{
                if(_turno == null){
                    _turno = new TurnoRepository(context);
                }
                return _turno;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}