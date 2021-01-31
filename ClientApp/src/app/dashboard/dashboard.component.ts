import { Component, OnInit } from '@angular/core';
import { ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  dashboardDetails: any;
  tagName = [];
  noOfArticle = [];
  polarChartDetails: Array<any>;
  trending;
  userId: any;
  constructor(private dashboardService: DashboardService) { }
  barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true,
    scales: {
      xAxes: [
        {
          barThickness: 20,
        }
      ]
    },
    legend: { display: true, labels: { fontColor: 'black' } }
  };
  public barChartLabels = ['January', 'February', 'March', 'April', 'May', 'June', 'july'];
  public barChartType = 'bar';
  public barChartData = [
    {data: [0, 5, 10, 15, 20, 25, 30, 35, 40], label: 'Number of read articles'}
  ];
  public chartColors: Array<any> = [
    { 
      backgroundColor: '#bd4848',
      borderColor: '#bd4848',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
    }];

//polar chart
  public polarAreaChartLabels: Label[] = this.tagName;
  public polarAreaChartData: SingleDataSet = this.noOfArticle;
public polarAreaChartType: ChartType = 'polarArea';
public polarChartColors: Array<any> = [
  { 
    backgroundColor: ['#d68e23', '#0a403c', '#9a9494', '#490437', '#2650d2']
  }
]

  ngOnInit() {
    this.userId = localStorage.getItem("userId");
    this.dashboardService.getDashboardDetails(this.userId).subscribe((result) => {
      this.dashboardDetails = result;
      this.polarChartDetails = result.polarChartTags;
      this.trending = result.trendingArticle;
      for (let i = 0; i < this.polarChartDetails.length; i++) {
        this.tagName.push(this.polarChartDetails[i].tagName);
        this.noOfArticle.push(this.polarChartDetails[i].noOfArticles);
      }
      console.log(this.trending);
    });
  }

}
