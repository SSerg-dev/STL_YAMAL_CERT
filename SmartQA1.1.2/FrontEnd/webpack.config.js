const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
var local = '/FrontEnd/source';
var tpnet = '/SmartPlant/FrontEnd/source';
var urlHost = tpnet;

module.exports = {
	entry: './src/index.js', //source/ABDFinalFolder.js
    output: {
        path: path.resolve(__dirname, './source'),
        filename: 'bundle.js',
        libraryTarget: 'var',
        library: 'EntryPoint'
    },

module: {
    rules:
        [
            {   
                test: /\.jsx?$/, 
                exclude: /node_modules/, 
                use: 
                {
                    loader: 'babel-loader', 
                    query: {presets: ['stage-3', 'react']}
                }
            },
            {   
                test: /\.css$/, 
                use: ExtractTextPlugin.extract({
                    fallback: "style-loader",
                    use: "css-loader"
                })
            },
            //{ test: /\.js$/, exclude: /node_modules/, loader: "babel-loader" },
            {
                test: /\.png/,
                use:
                    {
                        loader: 'file-loader',
                        options: {
                            publicPath: urlHost
                        }
                    }
            },
            {
                test: /\.gif/,
                use:
                    {
                        loader: 'file-loader',
                        options: {
                            publicPath: urlHost
                        }
                    }
            },
            {
                test: /\.ttf$/,
                loader: "url-loader", // or directly file-loader
                include: path.resolve(__dirname, "node_modules/react-native-vector-icons"),
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin("styles.css")
    ]
}