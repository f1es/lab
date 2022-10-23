#include <iostream>

using namespace std;

void N1();
void N2()
void N3()
void N4()

int main()
{



}

void N1()
{
    int arr[10] = { 1 ,6 ,12 ,4, 11 ,- 6 ,7 ,2 ,10 , 8 };
    int max = 0, temp;

    for (int i = 0; i < 10; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
            temp = i;
        }
    }

    for (int i = 0; i < 10; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;

    for (int i = ++temp; i < 10; i++)
    {
        arr[i] = 0;
    }
    for (int i = 0; i < 10; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;
}

void N3()
{
    const int n = 5;
    int arr[n][n];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
        {
            arr[i][j] = rand() % 10;
        }

    int sum = 0, temp_sum = 0, ryad = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++)
        {
            temp_sum += arr[i][j];
        }
        if (temp_sum > sum)
        {
            sum = temp_sum;
            ryad = i;
        }
        temp_sum = 0;
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++)
        {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }

    cout << "max sum = " << sum << " ryad = " << ryad + 1 << endl;
    for (int j = 0; j < n; j++)
    {
        cout << arr[ryad][j] << " ";
    }

    cout << endl;
}

void N4()
{
    const int n = 5;
    int arr[n][n];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
        {
            arr[i][j] = rand() % 10;
        }

    int min_temp = 2147483647, min_sum = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++)
        {
            if (arr[j][i] < min_temp) min_temp = arr[j][i];
        }
        min_sum += min_temp;
   cout << "min 4islo stolbca - " << i << " eto - " << min_temp << endl;
        min_temp = 2147483647;
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++)
        {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }

    cout << "minsum = " << min_sum << endl;

    cout << endl;
}



void N2()
{
    int arr[17] = { 7 ,-7  ,-9 ,6, 2, -18, 5, -47, 12, 5, 91, 6, 9, -4, 5, 6, 13 };

    for (int i = 0; i < 10; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;

    float sum = 0, counter = 0;
    for (int i = 0; i < 10; i++)
    {
        if (arr[i] % 2 == 1 and arr[i] > 0)
        {
            sum += arr[i];
            counter++;
        }
    }

    sum = sum / counter;

    cout << sum;
    cout << endl;
}
