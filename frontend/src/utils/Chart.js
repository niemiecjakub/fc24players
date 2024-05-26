export const toRadarChartData = (data) => {
    const statKeys = {
        pac: 'PAC',
        sho: 'SHO',
        pas: 'PAS',
        dri: 'DRI',
        def: 'DEF',
        phy: 'PHY'
    };
    
    const chartData = Object.keys(statKeys).map(key => ({
        stat: statKeys[key],
        value: data[key],
        fullMark: 99
    }));

    return chartData;
}