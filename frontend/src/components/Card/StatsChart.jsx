import {Radar, RadarChart, PolarGrid, PolarAngleAxis, ResponsiveContainer, Tooltip} from 'recharts';

export const StatsChart = ({data}) => {
    return (
        <ResponsiveContainer width={300} height={300}>
            <RadarChart cx="50%" cy="50%" outerRadius="80%" data={data}>
                <PolarGrid />
                <PolarAngleAxis dataKey="stat" />
                <Tooltip />
                <Radar dataKey="value" stroke="#8884d8" fill="#8884d8" fillOpacity={0.6} />
            </RadarChart>
        </ResponsiveContainer>
    )
}