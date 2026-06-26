using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperPrice.BLL.Idiomas
{
    public class Traductor : ISubject
    {
        private static Traductor instancia;

        private List<IObserver> observadores =
            new List<IObserver>();

        public Idioma IdiomaActual { get; private set; }

        private Traductor()
        {
            IdiomaActual = new Idioma()
            {
                Id = 1,
                Nombre = "Español"
            };
        }

        public static Traductor ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Traductor();
            }

            return instancia;
        }

        public void CambiarIdioma(Idioma idioma)
        {
            IdiomaActual = idioma;

            Notificar();
        }

        public void Suscribir(IObserver observer)
        {
            if (!observadores.Contains(observer))
            {
                observadores.Add(observer);
            }
        }

        public void Desuscribir(IObserver observer)
        {
            observadores.Remove(observer);
        }

        public void Notificar()
        {
            foreach (IObserver observer in observadores)
            {
                observer.ActualizarIdioma();
            }
        }
    }
}
