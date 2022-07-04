using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public abstract class Persona // abstract es un MODIFICADOR DE CLASE, le indica a la clase que no puede ser instanciada, o sea que no pedo crear una Persona. Solo la uso para escribir código que luego será heredado a otras clases, se usa para no escribir las mismas propiedades en distintas clases, no repetir código
    {
        private DateTime _fechaNacimiento; //creamos un campo privado para la propiedad FechaNacimiento de tipo DateTime, y publicamente la voy a mostrar como string en la propiedad
        private int _numeroDeDocumento;

        public string Nombre { get; set; } // propiedades autoimplementadas
        public string Apellido { get; set; } // propiedades autoimplementadas
        public string FechaNacimiento // propiedad con campos explicitos
        {
            get
            {
                return _fechaNacimiento.ToString("dd/MM/yyyy");// transformo el datetime que me trae el campo privado _fechanacimiento en string para mostrarlo por pantalla
            }
            set
            {
                _fechaNacimiento = Convert.ToDateTime(value);// recibo un string y lo convierto a DateTime - value es una palabra reservada que representa el valor que se le pasa a la propiedad
            }
        }
        
        public string NumeroDeDocumento 
        {
            get
            {
                return _numeroDeDocumento.ToString(); //  el DNI se va a mostrar como string
            }
            set
            {
                int numeroDeDocumentoConvertido;
                var sePuedeConvertir = int.TryParse(value, out numeroDeDocumentoConvertido);//TryParse intenta convertir el string en entero, devolviendo un verdadero o falso, y además, através del out, guarda la conversión (si se pudo hacer) en el campo o variable que indiquemos / value es el string ingresado / out significa salida, es como un return y se guardará en el campo indicado
                if (!sePuedeConvertir)
                {
                    _numeroDeDocumento = 0;
                }
                else
                {
                    _numeroDeDocumento = numeroDeDocumentoConvertido;
                }
            } 
        }

        public int ObtenerEdad()
        {
            var fechaHoraActual = DateTime.Today;
            var edadDateTime = fechaHoraActual - _fechaNacimiento;// el resultado de restar dos DateTime es un TimeSpan (espacio de tiempo). El TimeSpan tiene muchos metodos cargados

            return (int)edadDateTime.TotalDays / 365; // TotalDays es un metodo de TimeSpan, me trae la catidad de días en ese lapso de tiempo, y lo divido en 365 para sacar los años. El resultado es un double, por lo que lo casteo a int
        }
    }
}
