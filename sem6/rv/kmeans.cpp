#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>
#include <random>
#include <fstream>

using namespace std;

const int countOfPoints = 16; // Кол-во точек
const int countOfDimensions = 2; // Кол-во измерений
const int countOfClusters = 3; // Кол-во кластеров

class Point 
{
private:
    float _position[countOfDimensions]; // Координаты точки
public:
    // Получить координаты точки
    float* GetPosition()
    {
        return _position;
    }
    // Установить координаты точки
    void SetPosition(float* position)
    {
        for (int i = 0; i < countOfDimensions; i++)
        {
            _position[i] = position[i];
        }
    }
    // Изменить координат всех измерений на 0
    void SetToZero()
    {
        for (int i = 0; i < countOfDimensions; i++)
        {
            _position[i] = 0;
        }
    }
};

class Cluster 
{
private:
    Point _centerPoint; // Центр кластера
    vector<Point> _points; // Точки кластера
public:
    // Получить центр кластера
    Point GetCenterPoint()
    {
        return _centerPoint;
    }
    // Установить центр кластера
    void SetCenterPoint(Point newCenterPoint)
    {
        _centerPoint = newCenterPoint;
    }
    // Добавить точку в кластер
    void AddPoint(Point point)
    {
        _points.push_back(point);
    }
    // Вывести все точки кластера
    void ViewPoints()
    {
        cout << "cluster have " << _points.size() << " points" << endl;
        for (int i = 0; i < _points.size(); i++)
        {
            cout << i << " point on position" << endl;
            for (int j = 0; j < countOfDimensions; j++)
            {
                cout << j << " dimension - " << _points[i].GetPosition()[j] << endl;
            }
        }
    }
    // Очистить точки кластера
    void ClearPoints()
    {
        _points.clear();
    }
    // Получить количество точек
    int GetPointsCount()
    {
        return _points.size();
    }
    // Посчитать центр кластера
    Point CalculateCenter()
    {
        Point pointsSum;
        pointsSum.SetToZero();
        for (int i = 0; i < GetPointsCount(); i++)
        {
            for (int j = 0; j < countOfDimensions; j++)
            {
                pointsSum.GetPosition()[j] += _points[i].GetPosition()[j];
            }
        }

        Point newCenter;
        newCenter.SetToZero();
        for (int i = 0; i < countOfDimensions; i++)
        {
            newCenter.GetPosition()[i] = pointsSum.GetPosition()[i] / GetPointsCount();
        }

        return newCenter;
    }
};

// Получить случайные координаты
float* GetRandomPosition()
{
    float position[countOfDimensions];
    for (int i = 0; i < countOfDimensions; i++)
    {
        position[i] = rand() % 250;
    }
    return position;
}
// Получить точку со случайными координатами
Point GetRandomPoint()
{
    Point p;
    p.SetPosition(GetRandomPosition());
    return p;
}

//old
float CalculateDistance(vector<float>& point1, vector<float>& point2) { // подсчет растояние между точками
    float distance = 0.0;
    for (int i = 0; i < countOfDimensions; i++) {
        distance += pow((point2[i] - point1[i]), 2);
    }
    return sqrt(distance);
}

// Считает расстояние между точками
float CalculateDistance(Point firstPoint, Point secondPoint) 
{
    float distance = 0; 
    for (int i = 0; i < countOfDimensions; i++)    //считает расстояние между каждым измерением точек
        distance += pow(firstPoint.GetPosition()[i] - secondPoint.GetPosition()[i], 2);
    distance = sqrt(distance);
    return distance;
}

//old
// присваиваем точки к кластеру
void AssignToClusters(vector<vector<float>>& points, vector<vector<float>>& centroids, vector<int>& clusterAssignments) {
    for (int i = 0; i < countOfPoints; i++) {
        float minDistance = numeric_limits<float>::max(); // берем значения что было с чем сравнивать
        int closestCentroid = -1;
        for (int j = 0; j < countOfClusters; j++) {
            float distance = CalculateDistance(points[i], centroids[j]);// считаем
            if (distance < minDistance) { // если ближе запомнаем
                minDistance = distance;
                closestCentroid = j;
            }
        }
        clusterAssignments[i] = closestCentroid;
    }
}

// Присваиваем точки к ближайшему кластеру
void AssignToClusters(vector<Point>& points, vector<Cluster>& clusters)
{
    for (int i = 0; i < countOfClusters; i++) //Очищаем существующие точки кластеров, чтобы их переприсвоить
        clusters[i].ClearPoints();

    for (int i = 0; i < countOfPoints; i++)
    {
        float minDistance = 99999999999; 
        int closestClusterKey = 0;
        for (int j = 0; j < countOfClusters; j++)
        {
            float distance = CalculateDistance(points[i], clusters[j].GetCenterPoint()); // Считаем расстояние между точкой и центром кластера
            if (distance < minDistance) // Если расстояние до кластера меньше чем уже существующее запоминаем его
            {
                minDistance = distance;
                closestClusterKey = j;
            }
        }
        clusters[closestClusterKey].AddPoint(points[i]); // Присваиваем кластеру который ранее запомнили точку с текущей итерации цикла
    }
}
//old
// считаем новые координаты центроидов
void updateCentroids(vector<vector<float>>& points, vector<vector<float>>& centroids, vector<int>& clusterAssignments) {
    for (int i = 0; i < countOfClusters; i++) {
        vector<float> newCentroid(countOfDimensions);
        int count = 0;
        for (int j = 0; j < countOfPoints; j++) {
            if (clusterAssignments[j] == i) {
                for (int l = 0; l < countOfDimensions; l++) {
                    newCentroid[l] += points[j][l];
                }
                count++;
            }
        }
        if (count > 0) {
            for (int l = 0; l < countOfDimensions; l++) {
                newCentroid[l] /= count; // делим на количество точек в кластере
            }
            centroids[i] = newCentroid;
        }
    }
}
// Обновляем центры кластеров
void UpdateClustersCentres(vector<Cluster>& clusters)
{
    for (int i = 0; i < countOfClusters; i++) //Устанавливаем новый центр для каждого кластера
    {
        clusters[i].SetCenterPoint(clusters[i].CalculateCenter());
    }
    //return clusters;
}

void kMeans(vector<vector<float>>& points, vector<vector<float>>& centroids, vector<float>& iterationTimes) {
    vector<int> OldclusterAssignments(countOfPoints);
    int count = 0;
    while (true) {
        float s = clock();
        vector<int> clusterAssignments(countOfPoints);
        AssignToClusters(points, centroids, clusterAssignments);
        updateCentroids(points, centroids, clusterAssignments);
        float e = clock();
        iterationTimes.push_back((e - s) / CLOCKS_PER_SEC);
        cout << "iteration " << count << endl;
        int countPoints = 0;
        for (int i = 0; i < countOfClusters; i++) {
            cout << "cluster " << i << ":" << endl;
            countPoints = 0;
            for (int j = 0; j < countOfPoints; j++) {
                if (clusterAssignments[j] == i) {
                    countPoints++;
                    cout << "point " << j << ": ";
                    for (int k = 0; k < countOfDimensions; k++) {
                        cout << points[j][k] << " ";
                    }
                    cout << endl;
                }
            }
            cout << "count points in cluster: " << countPoints << endl;
        }
        cout << "\n\n\n";
        if (clusterAssignments == OldclusterAssignments) { // если ничего не поменялось
            cout << "True" << count << endl;
            ofstream outFile("../../CountIteration.txt");//открываем файл
            if (outFile.is_open()) {
                outFile << count;
                outFile.close();//закрываем файл
            }
            else {
                cout << "Error, could not open file.";
            }
            break;
        }
        OldclusterAssignments = clusterAssignments;
        count++;
    }
}


int main() {

    Point p1;
    p1.SetPosition(GetRandomPosition());
    Point p2;
    p2.SetPosition(GetRandomPosition());
    cout << CalculateDistance(p1, p2) << endl;
    vector<Point> points;
    for (int i = 0; i < countOfPoints; i++)
    {
        Point p;
        p.SetPosition(GetRandomPosition());
        points.push_back(p);
    }
    /*Cluster c;
    c.AddPoint(p1);
    c.AddPoint(p2);
    c.ViewPoints();*/

    vector<Cluster> clusters;
    //vector<Point> points;

    for (int i = 0; i < countOfClusters; i++)
    {
        Cluster c;
        c.SetCenterPoint(GetRandomPoint());
        clusters.push_back(c);
    }

    AssignToClusters(points, clusters);

    for (int i = 0; i < countOfClusters; i++)
    {
        cout << i << " cluster have " << clusters[i].GetPointsCount() << " points" << endl;
    }

    UpdateClustersCentres(clusters);
    AssignToClusters(points, clusters);
    for (int i = 0; i < countOfClusters; i++)
    {
        cout << i << " cluster have " << clusters[i].GetPointsCount() << " points" << endl;
    }

    //cout << CalculateDistance(p1, p2) << endl;

    //cout << CalculateDistance(p1.GetPosition(), p2.GetPosition()) << endl;
    //vector<vector<float>> points(amountOfPoints, vector<float>(numberOfDimensions));
    //vector<vector<float>> centroids(numberOfClusters, vector<float>(numberOfDimensions));

    //vector<float> iterationTimes;
    //for (int i = 0; i < amountOfPoints; i++) { // ставим рандомно точки
    //    for (int j = 0; j < numberOfDimensions; j++) {
    //        points[i][j] = 1 + rand() % 100;
    //    }
    //}
    //for (int i = 0; i < numberOfClusters; i++) { // так же рандомно кластеры
    //    for (int j = 0; j < numberOfDimensions; j++) {
    //        centroids[i][j] = 1 + rand() % 100;
    //    }
    //}
    //float s = clock();//начало отсчета
    //kMeans(points, centroids, iterationTimes);
    //float e = clock();//конец отсчета
    //cout << "K-Means Algorithm Execution Time: " << (e - s) / CLOCKS_PER_SEC << " s" << endl;//время выполнения
    //ofstream outFile("../../IterationTimes.txt");//открываем файл
    //if (outFile.is_open()) {
    //    for (int i = 0; i < iterationTimes.size(); i++) {//записываем в него
    //        outFile << iterationTimes[i] << " ";
    //    }
    //    outFile.close();//закрываем файл
    //}
    //else { // если не получилось открыть файл
    //    cout << "Error, could not open file.";
    //}
    //return 0;
}

