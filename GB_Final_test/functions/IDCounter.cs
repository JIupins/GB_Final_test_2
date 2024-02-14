using GB_Final_test.data;
using System.Windows;

namespace GB_Final_test.functions
{
    internal class IDCounter
    {
        private int maxID;
        private List<AnimalList> _AnimalsList;

        public IDCounter()
        {
            ApplicationContext DB = new ApplicationContext();
            _AnimalsList = DB.AnimalsList.ToList();
        }

        private int GetMaxIDNum()
        {
            try
            {
                int[] animalCuantity = new int[_AnimalsList.Count];
                for (int i = 0; i < _AnimalsList.Count; i++)
                {
                    animalCuantity[i] = _AnimalsList[i].id;
                }
                maxID = animalCuantity.Max();

                return ++maxID;
            }
            catch (Exception A)
            {
                MessageBox.Show("Список животных пуст!", A.Message);
                return 0;
            }
        }

        public int GetNewIDNum()
        {
            return GetMaxIDNum() + 1;
        }
    }
}
