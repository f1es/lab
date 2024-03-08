#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>
#include <string>
#include <filesystem>

//Made by ilya flex
using namespace std;

const int PointsCount = 60000; // Кол-во точек      60 000
const int DimensionsCount = 11; // Кол-во измерений 11
const int ClustersCount = 12; // Кол-во кластеров   12
int maxIterations = 20; // Максимальное Кол-во итераций
string outputFile = "X:\\vs\\git\\ootpisp2\\siplasplas\\siplasplas\\IterationsTime.txt";

class Point
{
private:
    vector<float> _position; // Координаты точки
public:
    Point()
    {
        SetToZero();
    }
    Point(vector<float> position)
    {
        SetPosition(position);
    }
    // Получить координаты точки
    vector<float>& GetPosition()
    {
        return _position;
    }
    // Установить координаты точки
    void SetPosition(vector<float> position)
    {
        _position.clear();

        for (int i = 0; i < DimensionsCount; i++)
        {
            _position.push_back(position[i]);
        }
    }
    // Изменить координаты всех измерений на 0
    void SetToZero()
    {
        _position.clear();

        for (int i = 0; i < DimensionsCount; i++)
        {
            _position.push_back(0);
        }
    }
    // Вывести координаты точки
    void PrintCordinates()
    {
        for (int i = 0; i < DimensionsCount; i++)
        {
            cout << i + 1 << ":" << _position[i] << endl;
        }
    }
    // Оператор сравнения двух точек
    bool operator == (Point point) const
    {
        for (int i = 0; i < DimensionsCount; i++)
        {
            if (_position[i] != point.GetPosition()[i])
                return false;
        }

        return true;
    }
};

class Cluster
{
private:
    Point _centerPoint; // Центр кластера
    vector<Point> _points; // Точки кластера
public:
    Cluster()
    {
        _centerPoint.SetToZero();
    }
    Cluster(Point center)
    {
        _centerPoint = center;
    }
    // Получить центр кластера
    Point GetCenterPoint()
    {
        return _centerPoint;
    }
    // Установить центр кластера
    void SetCenterPoint(Point centerPoint)
    {
        _centerPoint = centerPoint;
    }
    // Добавить точку в кластер
    void AddPoint(Point point)
    {
        _points.push_back(point);
    }
    // Очистить точки кластера
    void ClearPoints()
    {
        _points.clear();
    }
    // Вывести все точки кластера
    void ViewPoints()
    {
        cout << "cluster have " << _points.size() << " points" << endl;
        cout << "   center" << endl;
        _centerPoint.PrintCordinates();
        for (int i = 0; i < _points.size(); i++)
        {
            cout << "   point " << i + 1 << endl;
            _points[i].PrintCordinates();
        }
    }
    // Получить количество точек
    int GetPointsCount()
    {
        return _points.size();
    }
    // Обновить центр кластера исходя из пренадлежащих ему точек
    void UpdateCenterPoint()
    {
        if (GetPointsCount() == 0) // Если у кластера нет точек то ничего не делаем
            return;

        Point pointsSum;
        for (int i = 0; i < GetPointsCount(); i++) // Считаем сумму измерений всех точек
        {
            for (int j = 0; j < DimensionsCount; j++)
            {
                pointsSum.GetPosition()[j] += _points[i].GetPosition()[j];
            }
        }

        Point newCenterPoint;
        for (int i = 0; i < DimensionsCount; i++) // Делим сумму каждого измерения на количество измерений
        {
            newCenterPoint.GetPosition()[i] = pointsSum.GetPosition()[i] / GetPointsCount();
        }

        SetCenterPoint(newCenterPoint); // Устанавливаем новый центр кластера
    }
};

class KMeans
{
private:
    vector<Point> _points;
    vector<Cluster> _clusters;
    // Считает расстояние между точками
    float CalculateDistance(Point firstPoint, Point secondPoint)
    {
        float distance = 0;
        for (int i = 0; i < DimensionsCount; i++)    // Считает расстояние между каждым измерением точек
            distance += pow(firstPoint.GetPosition()[i] - secondPoint.GetPosition()[i], 2);
        distance = sqrt(distance);
        return distance;
    }
    // Присваиваем точки к ближайшему кластеру
    void AssignPoints()
    {
        for (int i = 0; i < ClustersCount; i++) //Очищаем существующие точки кластеров, чтобы их переприсвоить
            _clusters[i].ClearPoints();

        for (int i = 0; i < PointsCount; i++)
        {
            float minDistance = INFINITY;
            int closestClusterIndex = 0;
            for (int j = 0; j < ClustersCount; j++)
            {
                float distance = CalculateDistance(_points[i], _clusters[j].GetCenterPoint()); // Считаем расстояние между точкой и центром кластера
                if (distance < minDistance) // Если расстояние до текущего кластера меньше чем расстояние до предыдущих, запоминаем расстояние и индекс кластера
                {
                    minDistance = distance;
                    closestClusterIndex = j;
                }
            }
            _clusters[closestClusterIndex].AddPoint(_points[i]); // Присваиваем точку ближайшему к ней кластеру
        }
    }
    // Обновляем центры кластеров
    void UpdateClustersCentres()
    {
        for (int i = 0; i < ClustersCount; i++) //Устанавливаем новый центр для каждого кластера
        {
            _clusters[i].UpdateCenterPoint();
        }
    }
public:
    KMeans(vector<Point> points, vector<Cluster> clusters)
    {
        _points = points;
        _clusters = clusters;
    }
    vector<Point> GetPoints()
    {
        return _points;
    }
    void SetPoints(vector<Point> points)
    {
        _points = points;
    }
    vector<Cluster> GetClusters()
    {
        return _clusters;
    }
    void SetClusters(vector<Cluster> clusters)
    {
        _clusters = clusters;
    }
    // Запуск алгоритма
    void Execute()
    {
        vector<Cluster> previousClusters = _clusters;
        int iterationCounter = 0;
        while (true)
        {
            iterationCounter++;
            AssignPoints();             // Присваиваем точки к ближайшему кластеру
            UpdateClustersCentres();    // Обновляем центры кластеров
            int counter = 0;
            for (int i = 0; i < ClustersCount; i++) // Проверка на схожесть текущих центров с предыдущими
            {
                if (previousClusters[i].GetCenterPoint() == _clusters[i].GetCenterPoint())
                    counter++;
            }
            if (counter == ClustersCount) // Если центры одинаковы алгоритм завершает работу
                break;

            if (iterationCounter == maxIterations) // Ограничение по количеству итераций
                break;

            previousClusters = _clusters;
        }

        cout << "Done, iterations count " << iterationCounter << endl;
    }

    void ExecuteWithOutput()
    {
        //AssignPoints();
        //PrintClustersPoints();

        vector<Cluster> previousClusters = _clusters;
        int iterationCounter = 0;
        while (true)
        {
            iterationCounter++;
            float startTime = clock();
            AssignPoints();             // Присваиваем точки к ближайшему кластеру
            UpdateClustersCentres();    // Обновляем центры кластеров
            float finishTime = clock();
            float iterationTime = (finishTime - startTime) / 1000;
            cout << "\t" << iterationCounter << " Iteration time " << iterationTime << "s" << endl;
            
            // Записиваем в файл время итерации
            WriteToFile(to_string(iterationCounter) + ":" + to_string(iterationTime) + "\n", outputFile);

            for (int i = 0; i < ClustersCount; i++)
            {
                cout << i + 1 << " cluster have " << _clusters[i].GetPointsCount() << " points" << endl;
            }

            int counter = 0;    // Счётчик одинаковых кластеров
            for (int i = 0; i < ClustersCount; i++) // Проверка на схожесть текущих центров с предыдущими
            {
                if (previousClusters[i].GetCenterPoint() == _clusters[i].GetCenterPoint())
                    counter++;
            }
            if (counter == ClustersCount) // Если центры одинаковы алгоритм завершает работу
                break;

            if (iterationCounter == maxIterations) // Ограничение по количеству итераций
                break;

            previousClusters = _clusters;
        }

        //PrintClustersPoints();

        cout << "Done, iterations count " << iterationCounter << endl;
    }

    void PrintClustersPoints()
    {
        for (int i = 0; i < ClustersCount; i++)
        {
            _clusters[i].ViewPoints();
        }
    }

    void WriteToFile(string str, string path)
    {
        ofstream outFile(path, fstream::app);
        if (outFile.is_open())
        {
            outFile << str;
            outFile.close();
        }
    }
};

// Получить случайные координаты
vector<float> GetRandomPosition(int maxLength)
{
    vector<float> position;
    for (int i = 0; i < DimensionsCount; i++)
    {
        position.push_back(rand() % maxLength);
    }
    return position;
}
// Получить точку со случайными координатами
Point GetRandomPoint(int maxLength)
{
    return Point(GetRandomPosition(maxLength));
}

int main() {

    int maxDimensionLength = 400;

    vector<Point> points;
    for (int i = 0; i < PointsCount; i++)
    {
        points.push_back(GetRandomPoint(maxDimensionLength));
    }
    vector<Cluster> clusters;
    for (int i = 0; i < ClustersCount; i++)
    {
        Cluster c;
        c.SetCenterPoint(GetRandomPoint(maxDimensionLength));
        clusters.push_back(c);
    }

    KMeans K(points, clusters);
    float startTime = clock();
    K.ExecuteWithOutput();
    float finishTime = clock();
    float algorithmTime = (finishTime - startTime) / 1000;
    cout << "   Execution time " << algorithmTime << "s";
    K.WriteToFile("final:" + to_string(algorithmTime), outputFile);
}

