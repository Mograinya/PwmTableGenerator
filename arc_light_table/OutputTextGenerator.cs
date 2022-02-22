using System.Text;

namespace pwmTableGenerator
{
    public static class OutputTextGenerator
    {
        public static string GetOutputText(string name, int[] values)
        {
            if (testInputValues(name, values) is string errorText && errorText != "")
            {
                return errorText;
            }

            return getOutputText(name, values);
        }

        private static string getOutputText(string typeAndName, int[] values)
        {
            const int valuesPerLine = 16;
            int valueCount = values.Length;
            int valueLength = getLastValueLength(values);
            StringBuilder sb = new StringBuilder();

            sb.Append(typeAndName + $"[{valueCount}] = {{\r\n  "); // Тип/название переменной, размер массива, открывающая скобка и отступ с новой строки

            for (int i = 0; i < valueCount; i++)
            {
                sb.Append(convertToString(values[i], valueLength));

                if (i == (valueCount - 1)) // Конец массива
                {
                    sb.Append("\r\n");
                }
                else if (i % valuesPerLine == (valuesPerLine - 1)) // Конец строки
                {
                    sb.Append(",\r\n  ");
                }
                else
                {
                    sb.Append(", ");
                }
            }

            sb.Append("};");

            return sb.ToString();
        }

        private static string testInputValues(string name, int[] values)
        {
            if ((name == null) || (name.Length < 1))
            {
                return "Name error.";
            }

            if ((values == null) || values.Length < 1)
            {
                return "Values error.";
            }

            return "";
        }

        private static int getLastValueLength(int[] values)
        {
            return values[values.Length - 1].ToString().Length; /* Подразумевается, что число положительное. */
        }

        private static string convertToString(int value, int length)
        {
            return value.ToString().PadLeft(length);
        }
    }
}
