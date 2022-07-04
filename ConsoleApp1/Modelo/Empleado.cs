using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public sealed class Empleado : Persona // sealed es otro modificador de clase, sirve para indicar que esta clase no va a poder ser heredada. Es el piso de la herencia
    {
        private int _salarioBruto;

        public string Ocupacion { get; set; }
        public string Empresa { get; set; }
        public string ObraSocial { get; set; }

        public int SalarioBruto 
        {
            set => _salarioBruto = value; // para poder definir el set necesita tener asociado un campo privado / la flechita => sirve como si fueran llaves pero cuando hay una única instrucción
        }

        public int SalarioNeto { get => ObtenerSalarioNeto(); }// salario neto sólo tiene get, se puede mostrar

        private int ObtenerSalarioNeto() // método para obtener el salario neto, el cálculo es privado
        {
            var salarioNeto = _salarioBruto * 0.85;
            return (int)salarioNeto;
        }
    }
}
