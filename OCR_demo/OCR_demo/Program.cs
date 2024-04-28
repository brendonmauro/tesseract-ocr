using Tesseract;

namespace OCR_Demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var testImage = @"C:\text_logo_17.png";

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();

                            Console.WriteLine("Taxa de Precisão: {0}", page.GetMeanConfidence());
                            Console.WriteLine("Texto: \r\n{0}", texto);
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: {0}", ex.Message);
            } finally
            {
                Console.ReadLine();
            }
    }
    }
}
