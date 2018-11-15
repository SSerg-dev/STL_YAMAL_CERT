const path = require('path')
const { VueLoaderPlugin } = require('vue-loader');

module.exports = {
  entry: "./ClientApp/app.js",
    output: {
      path: path.join(__dirname, 'wwwroot', 'dist'),
      publicPath: '/dist/',
      filename: '[name].js',
      library: '[name]_[hash]'
    },
  resolve: {
    extensions: [".webpack.js", ".web.js", ".ts", ".vue", ".js"],
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    }
  },
  mode: "development",
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
          { loader: "style-loader" },
          { loader: "css-loader" }
        ]
      },
      { 
        test: /\.(eot|svg|ttf|woff|woff2)$/, 
        use: "url-loader?name=[name].[ext]"
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin()
  ]
};