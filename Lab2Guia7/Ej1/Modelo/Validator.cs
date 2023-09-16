using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.Modelo
{
    static class Validator
    {
        static public string NormalizarYValidarDNI(string dni)
        {
            //normalizar dni.
            dni = dni.Replace(".", "").Replace(" ", "");
            //
            //verificar longitud dni
            bool esLongitudDNI = dni.Length == 7 || dni.Length == 8;
            //
            //verificar si solo hay caracteres numéricos
            bool tieneChrValidosDNI = true;
            string msgChrNoValidosDNI = "";
            for (int idx = 0; idx < dni.Length; idx++)
            {
                bool esValido = Char.IsNumber(dni[idx]);
                tieneChrValidosDNI &= esValido;
                if (esValido == false)
                    msgChrNoValidosDNI += $"{{pos:{idx + 1}, char:{{ {dni[idx]}}} }},";
            }
            //
            if (esLongitudDNI == false)
                throw new Exception($"DNI: longitud:{dni.Length}, esperado entre 7 y 8 digitos.");
            if(tieneChrValidosDNI==false)
                throw new Exception($"DNI: {msgChrNoValidosDNI}");

            return dni;
        }

        static public string NormalizarYValidarTelefono(string telefono)
        {
            //normalizar telefono
            telefono = telefono.Replace(".", "").Replace(" ", "").
                                Replace("(", "").Replace(")", "").
                                Replace("-", "");
            //
            //verificar longitud telefono
            bool esLongitudTel = telefono.Length == 10;
            //
            //verificar si solo hay caracteres numéricos
            bool tieneChrValidosTel = true;
            StringBuilder msgChrNoValidosTel = new StringBuilder();
            for (int idx = 0; idx < telefono.Length; idx++)
            {
                bool esValido = Char.IsNumber(telefono[idx]);
                tieneChrValidosTel &= esValido;
                if (esValido == false)
                    msgChrNoValidosTel.Append($"{{pos:{idx + 1}, char:{{{telefono[idx]}}} }},");
            }
            //
            if (esLongitudTel == false)
                throw new Exception($"TELEFONO: longitud:{telefono.Length}, esperado 10 digitos.");
            if (tieneChrValidosTel == false)
                throw new Exception($"TELEFONO: {msgChrNoValidosTel}");
            //
            return telefono;
        }

        static public string NormalizarYValidarEmail(string email)
        {
            //normalizar email
            email = email.Trim();
            //
            //verificar ocurrencias de @ ==1
            string[] camposEmail = email.Split('@');
            bool verificaArroba = camposEmail.Length == 2;
            //
            string usr = camposEmail[0];
            bool esLongitudUsr = usr.Length > 0;
            //
            //caracter inicial y otros caracteres del usuario
            bool tieneChrValidosUsr = true;
            string msgChrNoValidosUsr = "";
            for (int idx = 0; idx < usr.Length; idx++)
            {
                bool esValido = Char.IsLetterOrDigit(usr[idx]) || usr[idx] == '.';

                //verificando caracter inicial del campo usuario
                if (idx == 0) esValido &= Char.IsNumber(usr[idx]) == false;

                tieneChrValidosUsr &= esValido;
                if (esValido == false)
                    msgChrNoValidosUsr += $"{{pos:{idx + 1}, char:{{ {usr[idx]}}} }},";
            }
            //
            string dom = camposEmail[1];
            bool esLongitudDom = dom.Length > 0;
            //
            ////caracter inicial y otros caracteres del dominio
            bool tieneChrValidosDom = true;
            string msgChrNoValidosDom = "";
            for (int idx = 0; idx < dom.Length; idx++)
            {
                bool esValido = Char.IsLetterOrDigit(dom[idx]) || dom[idx] == '.';

                //verificando caracter inicial del campo dominio
                if (idx == 0) esValido &= Char.IsNumber(dom[idx]) == false;

                tieneChrValidosDom &= esValido;
                if (esValido == false)
                    msgChrNoValidosDom += $"{{pos:{idx + 1}, char:{{{dom[idx]}}} }}, ";
            }
            //
            if (verificaArroba == false)
                throw new Exception($"EMAIL: Formato no válido.");
            if (esLongitudUsr == false)
                throw new Exception($"EMAIL: Formato del usuario no válido.");
            if (tieneChrValidosUsr == false)
                throw new Exception($"EMAIL: {msgChrNoValidosUsr}");
            //
            if (esLongitudDom == false)
                throw new Exception($"EMAIL: Formato del dominio no válido.");
            if (tieneChrValidosDom == false)
                throw new Exception($"EMAIL: dominio:{msgChrNoValidosDom}");
            //
            return email;
        }

        static public string NormalizarYValidarDecimal(string valor)
        {
            //normalizar dni.
            valor = valor.Trim();
            //
            //verificar ocurrencias de ',' <=1
            string[] camposMonto = valor.Split(',');
            bool verificaComa = camposMonto.Length <= 2;
            //
            //verificar si solo hay caracteres numéricos
            bool tieneChrValidosMonto = true;
            string msgChrNoValidosMonto = "";
            for (int idx = 0; idx < valor.Length; idx++)
            {
                bool esValido = Char.IsNumber(valor[idx]) || valor[idx] == ',';
                tieneChrValidosMonto &= esValido;

                if (esValido == false)
                    msgChrNoValidosMonto += $"{{pos:{idx + 1}, char:{{ {valor[idx]} }} }}";
            }

            if (verificaComa == false)
                throw new Exception($"\t VALOR: Formato no válido, la coma es separador decimal.");
            if (tieneChrValidosMonto == false)
                throw new Exception($"\t VALOR: {msgChrNoValidosMonto}");

            return valor;
        }
    }
}
