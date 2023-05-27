using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class NewtonCalc
    {
        public int NewtonTask(int N,int K)
        {
            
            (int n, int k) tuple = (N, K);
            //licznik
            Task<int> licznik = Task.Factory.StartNew<int>((obj) =>
            {
                int n = (((int n,int k))obj).n;
                int k = (((int n, int k))obj).k;
                int sum = 1;
                for (int i = n-k+1; i <= n; i++) sum *= i;
                return sum;
            }, tuple);
            
            //mianownik
            Task<int> mianownik = Task.Factory.StartNew<int>((obj) =>
            {
                int max = (int)obj;
                int sum = 1;
                for (int i = 1; i <= max; i++) sum *= i;
               
                return sum;
            }, K);
            

            return licznik.Result/mianownik.Result;
        }

        

        public int NewtonDelegate(int N, int K)
        {

            int Licznik(int n, int k)
            {
                int sum = 1;
                for (int i = n - k + 1; i <= n; i++) sum *= i;
                return sum;
            }

            int Mianownik(int k)
            {
                int sum = 1;
                for (int i = 1; i <= k; i++) sum *= i;

                return sum;
            }

            Func<int, int, int> licznik = Licznik;
            Func<int, int> mianownik = Mianownik;

            IAsyncResult licznikResult = licznik.BeginInvoke(N, K, null, null);
            IAsyncResult mianownikResult = mianownik.BeginInvoke(K, null, null);

            while(!licznikResult.IsCompleted || !mianownikResult.IsCompleted)
            {
                //wait
            }

            return licznik.EndInvoke(licznikResult)/ mianownik.EndInvoke(mianownikResult);
        }



        public async Task<int> NewtonAsync(int N, int K)
        {

            async Task<int> Licznik(int n, int k)
            {
                int sum = 1;
                for (int i = n - k + 1; i <= n; i++) sum *= i;
                return  sum;   
            }

            async Task<int> Mianownik(int k)
            {
                int sum = 1;
                for (int i = 1; i <= k; i++) sum *= i;
                return sum;
            }

            Task<int> licznikTask = Licznik(N, K);
            Task<int> mianownikTask = Mianownik(K);

            int licznik = await licznikTask;
            int mianownik = await mianownikTask;


            return licznik/mianownik;
        }
    }
}
