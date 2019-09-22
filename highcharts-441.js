Highcharts.chart('container-441', {
    chart: {
        type: 'boxplot',
        zoomType: 'y'
    },
    title: {
        text: 'Corpus=Ndocs: 4; Nterms: 441'
    },
    legend: {
        enabled: false
    },
    xAxis: {
        categories: ['S/-/-', 'S/+/-', 'S/-/+', 'S/+/+', 'P/-/-', 'P/+/-', 'P/-/+', 'P/+/+', 'P2/-/-', 'P2/+/-', 'P2/-/+', 'P2/+/+'],
        title: {
            text: 'Applied techniques'
        }
    },
    yAxis: {
        title: {
            text: 'Benchmark (s)'
        }
    },
    series: [{
        name: 'Benchmark',
        data: [
            [93.4510, 93.4974, 93.5719, 93.5879, 93.6054],
            [88.8064, 88.8736, 88.9209, 88.9730, 89.0203],
            [46.3918, 46.4193, 46.4313, 46.4511, 46.4650],
            [42.4931, 42.5161, 42.5276, 42.6088, 42.6176],
            [21.1739, 21.7005, 21.9864, 22.2013, 22.5901],
            [20.4480, 20.6666, 21.0242, 21.2958, 21.9504],
            [10.5549, 10.6876, 10.7617, 10.9077, 11.2241],
            [9.9907, 10.1031, 10.1688, 10.2592, 10.3996],
            [21.0030, 21.0174, 21.0384, 21.0615, 21.1257],
            [21.1716, 21.1740, 21.1804, 21.1991, 21.2285],
            [10.6343, 10.6378, 10.6456, 10.6583, 10.6842],
            [9.2621, 9.2725, 9.2762, 9.3354, 9.3923]
        ],
        tooltip: {
            headerFormat: '<em>Algo {point.key}</em><br/>'
        }
    }]
});