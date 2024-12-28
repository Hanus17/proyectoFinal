using System;

namespace Exercises
{
    class Program
    {
        //Métodos
        static void Main2(string[] args)
        {
            int initialStock = 50;
            int quantityToAdd = 20;
            int addedQuantity;

            UpdateStock(initialStock, quantityToAdd, out int updatedStock, out addedQuantity);

            Console.WriteLine($"Inventario inicial: {initialStock}");
            Console.WriteLine($"Cantidad agregada: {quantityToAdd}");
            Console.WriteLine($"Inventario actualizado: {updatedStock}");

            //Ajuste de entrada
            AdjustStock(ref updatedStock, 10);
            Console.WriteLine($"Ajuste de entrada: {updatedStock}");

            //Ajuste de salida
            AdjustStock(ref updatedStock, -20);
            Console.WriteLine($"Ajuste de salida: {updatedStock}");


            //´Lectura de producto
            //El var ocupa cierto espacio de memoria
            //porque no conoce el tipo de dato.
            //var productInfo = GetProductInfo("Laptop", 20);
            //productInfo.productName
            //productInfo.stock
            Console.WriteLine();
            (string productName, int stock) = GetProductInfo("Laptop", 20);
            Console.WriteLine($"Nombre del producto: {productName}");
            Console.WriteLine($"Inventario del producto: {stock}");

            Console.ReadKey();
        }

        public static void UpdateStock (int initialStock, int quantityToAdd, out int updatedStock, out int addedQuantity)
        {
            addedQuantity = quantityToAdd;
            updatedStock = initialStock + addedQuantity;
        }
       
        public static void AdjustStock(ref int stock, int adjustment)
        {
            stock += adjustment;
        }

        public static (string productName, int stock) GetProductInfo(string productName, int stock)
        {
            return (productName, stock);
        }

      
    }
}
