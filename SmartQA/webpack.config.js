const path = require('path');
const { VueLoaderPlugin } = require('vue-loader');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const TerserPlugin = require('terser-webpack-plugin')
const devMode = process.env.NODE_ENV === 'development';

module.exports = {
    mode: devMode ? "development" : "production",
    entry: './ClientApp/app.js',
    output: {
        path: path.join(__dirname, 'wwwroot', 'dist'),
        publicPath: '/dist/',
        filename: '[name].js',
        library: '[name]_[hash]'
    },
    resolve: {
        modules: [
            path.resolve('./ClientApp'),
            path.resolve('./node_modules')
        ],

        extensions: ['.webpack.js', '.web.js', '.ts', '.vue', '.js'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    esModule: true
                }
            },
            {
                test: /\.css$/,
                use: [
                    //devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
                    MiniCssExtractPlugin.loader,
                    'css-loader'
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    //devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
                    MiniCssExtractPlugin.loader,
                    {
                        loader: 'css-loader'
                        //options: { url: false }
                    },
                    'sass-loader' // compiles Sass to CSS, using Node Sass by default
                ]
            },
            {
                test: /\.(png|jp(e*)g|svg)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[path][name]_[hash].[ext]',
                            context: path.resolve(__dirname, "ClientApp/"),
                            outputPath: '',
                            publicPath: '.',
                            useRelativePaths: true
                        }
                    }]
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)$/,
                use: 'url-loader?name=[name].[ext]'
            }
        ]
    },
    optimization: {
        minimizer: [
            new OptimizeCSSAssetsPlugin({
                cssProcessorPluginOptions: {
                    preset: ['default', { discardComments: { removeAll: true } }],
                },
            }),
            new TerserPlugin({
                parallel: true,
                terserOptions: {
                    ecma: 6,
                    output: {
                        comments: false,
                    },
                },
            })],
    },
    plugins: [
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
            path: path.join(__dirname, 'wwwroot', 'dist'),
            publicPath: '/dist/',
            filename: "[name].css",
            chunkFilename: "[id].css"
        })
    ]
};