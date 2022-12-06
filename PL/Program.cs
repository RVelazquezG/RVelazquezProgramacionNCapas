using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {

            int Menu, Opcion1, Opcion2, Opcion3, Opcion4, Opcion5, Opcion6;
            Console.WriteLine("Seleccione el apartado que desea consultar: \n");
            Console.WriteLine("1.-Aseguradora \n2.-Aseguradora \n3.-UsuarioEF \n4.-AseguradoraEF \n5.-UsuarioLinq \n6.-AseguradoraLinq\n");
            Menu = Convert.ToInt32(Console.ReadLine());

            if (Menu == 1)
            {

                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar un nuevo usuario \n2.-Actualizar registro de usuario \n3.-Eliminar registro de usuario \n4.-Consultar todos los registros de usuario \n5.-Consultar los registros de un usuario\n");
                Console.WriteLine("******************************************************\n");
                Opcion1 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion1)
                {
                    case 1:
                        PL.Usuario.Add();
                        break;

                    case 2:
                        PL.Usuario.Update();
                        break;

                    case 3:

                        PL.Usuario.Delete();
                        break;

                    case 4:
                        PL.Usuario.GetAll();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Usuario.GetById();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            }

            if (Menu == 2)
            {
                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar una nueva aseguradora \n2.-Actualizar registro de aseguradora \n3.-Eliminar registro de una aseguradora \n4.-Consultar todos los registros de aseguradora \n5.-Consultar los registros de una sola aseguradora\n");
                Console.WriteLine("******************************************************\n");
                Opcion2 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion2)
                {
                    case 1:
                        PL.Aseguradora.Add();
                        break;

                    case 2:
                        PL.Aseguradora.Update();
                        break;

                    case 3:

                        PL.Aseguradora.Delete();
                        break;

                    case 4:
                        PL.Aseguradora.GetAll();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Aseguradora.GetById();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }


            }

            if (Menu == 3)
            {

                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar un nuevo usuario \n2.-Actualizar registro de usuario \n3.-Eliminar registro de usuario \n4.-Consultar todos los registros de usuario \n5.-Consultar los registros de un usuario\n");
                Console.WriteLine("******************************************************\n");
                Opcion3 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion3)
                {
                    case 1:
                        PL.Usuario.AddEF();
                        break;

                    case 2:
                        PL.Usuario.UpdateEF();
                        break;

                    case 3:

                        PL.Usuario.DeleteEF();
                        break;

                    case 4:
                        PL.Usuario.GetAllEF();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Usuario.GetByIdEF();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            }
            if (Menu == 4)
            {
                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar una nueva aseguradora \n2.-Actualizar registro de aseguradora \n3.-Eliminar registro de una aseguradora \n4.-Consultar todos los registros de aseguradora \n5.-Consultar los registros de una sola aseguradora\n");
                Console.WriteLine("******************************************************\n");
                Opcion4 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion4)
                {
                    case 1:
                        PL.Aseguradora.AddEF();
                        break;

                    case 2:
                        PL.Aseguradora.UpdateEF();
                        break;

                    case 3:

                        PL.Aseguradora.Delete();
                        break;

                    case 4:
                        PL.Aseguradora.GetAllEF();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Aseguradora.GetByIdEF();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            }
            if (Menu == 5)
            {

                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar un nuevo usuario \n2.-Actualizar registro de usuario \n3.-Eliminar registro de usuario \n4.-Consultar todos los registros de usuario \n5.-Consultar los registros de un usuario\n");
                Console.WriteLine("******************************************************\n");
                Opcion5 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion5)
                {
                    case 1:
                        PL.Usuario.AddLinq();
                        break;

                    case 2:
                        PL.Usuario.UpdateLinq();
                        break;

                    case 3:

                        PL.Usuario.DeleteLinq();
                        break;

                    case 4:
                        PL.Usuario.GetAllLinq();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Usuario.GetByIdLinq();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            }
            if (Menu == 6)
            {
                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar una nueva aseguradora \n2.-Actualizar registro de aseguradora \n3.-Eliminar registro de una aseguradora \n4.-Consultar todos los registros de aseguradora \n5.-Consultar los registros de una sola aseguradora\n");
                Console.WriteLine("******************************************************\n");
                Opcion6 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion6)
                {
                    case 1:
                        PL.Aseguradora.AddLinq();
                        break;

                    case 2:
                        PL.Aseguradora.UpdateLinq();
                        break;

                    case 3:

                        PL.Aseguradora.DeleteLinq();
                        break;

                    case 4:
                        PL.Aseguradora.GetAllLinq();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Aseguradora.GetByIdEF();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            }

            else
            {
                Console.WriteLine("La opcion solicitada no es correcta");
            }

        }
    }
}

