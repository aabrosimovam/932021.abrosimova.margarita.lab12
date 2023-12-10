namespace _932021.abrosimova.margarita.lab11
{
    public class CalculatorDataModel
    {
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public string operation { get; set; }
        public int resNum;

        public bool showOperation = false;
        public bool errorEmpty;
        public bool errorDivZero;
        public bool errorUnknown;

        public void calculation()
        {
            char operationChar = Convert.ToChar(operation);
            errorDivZero = false;
            errorUnknown = false;

            int dummyNum;
            if (int.TryParse(FirstValue, out dummyNum) && int.TryParse(SecondValue, out dummyNum))
            {
                errorEmpty = false;
            }
            else
            {
                errorEmpty = true;
                return;
            }

            int FirstValueInt = Int32.Parse(FirstValue);
            int SecondValueInt = Int32.Parse(SecondValue);
            switch (operationChar)
            {
                case '+':
                    resNum = FirstValueInt + SecondValueInt;
                    break;
                case '-':
                    resNum = FirstValueInt - SecondValueInt;
                    break;
                case '*':
                    resNum = FirstValueInt * SecondValueInt;
                    break;
                case '/':
                    if (SecondValueInt != 0)
                        resNum = FirstValueInt / SecondValueInt;
                    else
                        errorDivZero = true;
                    break;
                default:
                    errorUnknown = true;
                    break;
            }
        }
    }
}