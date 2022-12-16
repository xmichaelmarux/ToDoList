Html using system
using System.Collections.Generic;
using System.Linq;

namespace Primerproyecto
{
	class Program
	{
		static void Main(string[] args)
		{
			Program data = new();
			data.ToDoList();	
		}
		private void ToDoList()
        {			
			string opcion;
			List<string> elementos = new List<string>();
			do
			{
				Console.WriteLine("\t\tBIENVENIDO AL PROGRAMA TO-DO-LIST\n\n");
				Console.WriteLine("Elige una opcion : \n" +
								"1)Añada una tarea\n" +
								"2)Señalar tarea realizada(*)\n" +
								"3)Mostrar toda la lista de tareas\n" +
								"4)Borrar tarea\n\n" +
								"0)Salir");

				opcion = Convert.ToString(Console.ReadLine());
				Console.Clear();
				switch (opcion)
				{
					case "1":
						Console.WriteLine("Añade una tarea :\n");
						string valor = Console.ReadLine().ToLower();
						switch (valor)
                        {
							case "":
								Console.WriteLine("Escriba una tarea valida");
								break;
							default:
								if (elementos.Contains(valor))
								{
									Console.WriteLine("La tarea ya se encuentra en la lista");
								}
								else
								{
									elementos.Add(valor);
									Console.WriteLine("La tarea se agrego a la lista correctamente");
								}
								break;
						}
						Console.ReadKey();
						Console.Clear();
						break;
					case "2":
						Console.WriteLine("Que tarea deseas marcar como Realizada :\n");
						string encontrar = Convert.ToString(Console.ReadLine());
						if (encontrar == "" || encontrar.All(char.IsLetter))
						{
							Console.WriteLine("Escribe un caracter valido");
						}
						else
						{
							int convertir = Convert.ToInt32(encontrar);
							if (convertir > elementos.Count || convertir < 0)
							{
								Console.WriteLine("La tarea no se encuentra en la lista");
							}
							else
							{
								string item = Convert.ToString("(*) " + elementos[convertir]);
								if (elementos[convertir].Contains(("*")))
								{
									Console.WriteLine("La tarea ya se encuentra marcada");
								}
								else
								{
									int elem = elementos.IndexOf(elementos[convertir]);
									Console.WriteLine("Se ha encontrado la tarea " +
														"\n{0}){1}\nse marcara con un (*)",
														elem, elementos[convertir]);
									elementos.Insert(convertir, item);
									elementos.RemoveAt(convertir + 1);
								}
							}
						}
                        Console.ReadKey();
						Console.Clear();
						break;
					case "3":
						int list = elementos.Count;
						for (int j = 0; j < list; j++)
						{
                            Console.WriteLine(j + ") " + elementos[j]);
                        }
						Console.WriteLine("\nPresione cualquier tecla para continuar...");
						Console.ReadKey();
						Console.Clear();
						break;
					case "4":
						Console.WriteLine("Que tarea deseas eliminar :\n");
						string validar = Convert.ToString(Console.ReadLine());
						if(validar.All(char.IsLetter) || validar == "")
                        {
							Console.WriteLine("Escribe un caracter valido");
						}
                        else
                        {
							int borrar = Convert.ToInt32(validar);
							if (borrar < 0 || borrar > elementos.Count)
                            {
								Console.WriteLine("La tarea no se encuentra en la lista");
							}
                            else
                            {
								Console.WriteLine("Se ha eliminado la tarea :\n\n{0}) {1}", elementos.IndexOf(elementos[borrar]), elementos[borrar]);
								elementos.RemoveAt(borrar);
							}
						}
						Console.WriteLine("\nPresione cualquier tecla para continuar...");
						Console.ReadKey();
						Console.Clear();
						break;
					case "0":
						opcion = "";
						break;
					case "":
						opcion = "*";
						break;
				}
			}
			while (opcion != "");
		}
	}
}
