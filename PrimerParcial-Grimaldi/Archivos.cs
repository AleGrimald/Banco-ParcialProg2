using System;
using System.IO;

namespace PrimerParcial_Grimaldi
{
    public class Archivos
    {
        private readonly string ruta = "./usuariosBanco.txt";

        public void EscribirArchivo(dynamic[] datos)
        {
            try
            {
                using (StreamWriter escritor = File.AppendText(ruta))
                {
                    escritor.WriteLine($"{datos[0]}|{datos[1]}|{datos[2]}|{datos[3]}|{datos[4]}|{datos[5]}|{datos[6]}|{datos[7]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public string[] LeerArchivo()
        {
            try
            {
                string[] lineas = File.ReadAllLines(ruta);
                return lineas;
            }
            catch (IOException ex)
            {
                string[] error = { $"Error de Lectura: {ex.Message}" };
                return error;
            }
            catch(Exception ex)
            {
                string[] error = { $"Error: {ex.Message}" };
                return error;
            }
            
        }

        public void ModificarArchivo(dynamic[] datos)
        {
            try
            {
                using (StreamWriter escritor = File.CreateText(ruta))
                {
                    for (int i = 0; i < datos.Length; i++)
                    {
                        escritor.WriteLine($"{datos[i][0]}|{datos[i][1]}|{datos[i][2]}|{datos[i][3]}|{datos[i][4]}|{datos[i][5]}|{datos[i][6]}|{datos[i][7]}");
                    }
                    
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
