using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lista_Doblemente_Enlazada
{
    class Lista
    {
        private Nodo head;
        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }

        public Lista()
        {
            head = null;
        }

        public Lista(Nodo n)
        {
            head = n;
        }

        public void Insertar(Nodo n)
        {

            if (head == null)
            {
                n.Anterior = null;
                n.Siguiente = null;
                head = n;
                return;
            }

            if (n.Dato < head.Dato)
            {
                n.Siguiente = head;
                n.Anterior = null;
                head = n;
                return;
            }

            Nodo h = head;

            while (h.Anterior != null)
            {
                if (h.Anterior.Dato > n.Dato)
                {
                    break;
                }
                h = h.Anterior; //regresa al nodo anterior
            }

            if (h.Anterior != null)
            {
                n.Anterior = h.Anterior;
                h.Anterior = n;
                return;
            }
            h.Anterior = n;

            while (h.Siguiente != null)
            {
                if (h.Siguiente.Dato > n.Dato)
                {
                    break;
                }
                h = h.Siguiente; //avanza al siguiente nodo
            }

            if (h.Siguiente != null)
            {
                n.Siguiente = h.Siguiente;
                h.Siguiente = n;
                return;
            }
            h.Siguiente = n;
           
        }

        public void Eliminar(int dato)
        {
            if (head != null)
            {
                if (head.Dato == dato)
                {
                    head = head.Siguiente;
                    head.Anterior = null;
                    return;
                }
                Nodo h = head;

                while (h.Anterior != null)
                {
                    if (h.Anterior.Dato == dato)
                    {
                        h.Anterior = h.Anterior.Anterior;
                        return;
                    }
                    h = h.Anterior;
                }

                while (h.Siguiente != null)
                {
                    if (h.Siguiente.Dato == dato)
                    {
                        h.Siguiente = h.Siguiente.Siguiente;
                        return;
                    }
                    h = h.Siguiente;
                }               
            }
        }

        public override string ToString()
        {
            string lista = "";
            Nodo h = head;
            if (h != null)
            {
                lista += h.ToString();

                h = h.Siguiente;
                while (h != null)
                {
                    //lista += h.ToString() + ",";
                    lista += "," + h.ToString();

                    h = h.Siguiente;
                }
                return lista;
            }
            else
            {
                return "La lista esta vacia";
            }

        }

        public bool BuscarDato(int a)
        {
            Nodo h = head;
            if (h != null)
            {
                while (h != null)
                {
                    if (h.Dato == a)
                    {
                        return true;
                    }
                    h = h.Siguiente;
                    //h.Siguiente.Anterior = h.Anterior.Siguiente;
                }
            }
            return false;
        }
 
        public int ContarNodos()
        {
            int contador = 0;
            Nodo h = head;
            while (h != null)
            {
                contador++;

                h = h.Siguiente;
            }
            return contador;
        }

        public void Guardar(string Ruta, string Datos)
        {
            if (File.Exists(Ruta))
            {
                File.Delete(Ruta);
            }
            using (StreamWriter sw = File.CreateText(Ruta))
            {
                sw.WriteLine(Datos);
            }
        }
    }
}
