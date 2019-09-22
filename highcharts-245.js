Highcharts.chart('container-245', {
    chart: {
        type: 'boxplot',
        zoomType: 'y'
    },
    title: {
        text: 'Corpus=Ndocs: 3; Nterms: 245'
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
            [7.7759, 7.7795, 7.7802, 7.7811, 7.7835],
            [7.4398, 7.4474, 7.4515, 7.4535, 7.4606],
            [3.9909, 3.9930, 3.9937, 3.9949, 3.9981],
            [3.6103, 3.6133, 3.6146, 3.6152, 3.6192],
            [1.8653, 1.9455, 1.9743, 2.0236, 2.0882],
            [1.7821, 1.8558, 1.9040, 1.9622, 2.0759],
            [0.9588, 0.9958, 1.0336, 1.0866, 1.1296],
            [0.8469, 0.8834, 0.8987, 0.9277, 0.9686],
            [1.7764, 1.7801, 1.7844, 1.7869, 1.7950],
            [1.6542, 1.6600, 1.6645, 1.6713, 1.6849],
            [0.8919, 0.8929, 0.8944, 0.8955, 0.8972],
            [0.8356, 0.8365, 0.8382, 0.8397, 0.8525]
        ],
        tooltip: {
            headerFormat: '<em>Algo {point.key}</em><br/>'
        }
    }]
});