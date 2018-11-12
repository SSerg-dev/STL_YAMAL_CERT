const path = require('path');

module.exports = {
	entry: './Scripts/src/index.js', //source/ABDFinalFolder.js
    output: {
        path: path.resolve(__dirname, './source'),
        filename: 'bundle.js',
        libraryTarget: 'var',
        library: 'EntryPoint'
    },

module: {
    rules:
    [
        { test: /\.js$/, exclude: /node_modules/, loader: "babel-loader" },
        { test: /\.png/, loader: 'file-loader' },
        {
            test: /\.ttf$/,
            loader: "url-loader", // or directly file-loader
            include: path.resolve(__dirname, "node_modules/react-native-vector-icons"),
        }
    ]
    },
module: {
        loaders: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'babel-loader',
                query: {
                    presets: ['env', 'react']
                }
            }
        ]
    }
}