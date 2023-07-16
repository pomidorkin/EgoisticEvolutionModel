using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using E2C;

public class ChartController : MonoBehaviour
{
    private int day = 0;
    [SerializeField] E2Chart myChart;
    private E2ChartData.Series series1;
    void Start()
    {
        //Add chart component
        myChart.chartType = E2Chart.ChartType.LineChart;

        //add chart options
        myChart.chartOptions = myChart.gameObject.AddComponent<E2ChartOptions>();
        myChart.chartOptions.title.enableTitle = true;
        myChart.chartOptions.title.enableSubTitle = false;
        myChart.chartOptions.yAxis.enableTitle = true;
        myChart.chartOptions.label.enable = true;
        myChart.chartOptions.legend.enable = true;
        myChart.chartOptions.chartStyles.lineChart.enableShade = true;
        myChart.chartOptions.chartStyles.barChart.barWidth = 15.0f;
        myChart.chartOptions.plotOptions.mouseTracking = E2ChartOptions.MouseTracking.None;

        //add chart data
        myChart.chartData = myChart.gameObject.AddComponent<E2ChartData>();
        myChart.chartData.title = "Slime Population";
        myChart.chartData.yAxisTitle = "Population";
        myChart.chartData.categoriesX = new List<string> { "Δενό" + day}; //set categories

        //create new series
        series1 = new E2ChartData.Series();
        series1.name = "Altruist Slimes";
        series1.dataY = new List<float>();
        series1.dataY.Add(0);
        /*series1.dataY.Add(95.8f);
        series1.dataY.Add(53.6f);
        series1.dataY.Add(36.4f);
        series1.dataY.Add(45.9f);
        series1.dataY.Add(87.4f);*/

        /*E2ChartData.Series series2 = new E2ChartData.Series();
        series2.name = "Storage";
        series2.dataY = new List<float>();
        series2.dataY.Add(182.8f);
        series2.dataY.Add(36.5f);
        series2.dataY.Add(98.3f);
        series2.dataY.Add(99.7f);
        series2.dataY.Add(36.2f);
        series2.dataY.Add(78.9f);*/

        //add series into series list
        myChart.chartData.series = new List<E2ChartData.Series>();
        myChart.chartData.series.Add(series1);
        //myChart.chartData.series.Add(series2);

        //update chart
        myChart.UpdateChart();
    }

    public void AddDataToChart(int populationAmount)
    {
        day++;
        series1.dataY.Add(populationAmount);
        myChart.chartData.categoriesX.Add("Δενό" + day);

        myChart.UpdateChart();
    }

}
