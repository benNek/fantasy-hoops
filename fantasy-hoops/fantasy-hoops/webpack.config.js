const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
  const isDevBuild = !(env && env.prod);
  return [{
    stats: { modules: false },
    entry: { 'main': './ClientApp/boot.jsx' },
    resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
    output: {
      path: path.join(__dirname, bundleOutputDir),
      filename: '[name].js',
      publicPath: 'dist/'
    },
    module: {
      rules: [
        { test: /\.html$/, loader: 'html-loader?attrs[]=video:src' },
        { test: /\.(mov|mp4)$/, loader: 'url-loader' },
        { test: /\.tsx?$/, include: /ClientApp/, use: 'awesome-typescript-loader?silent=true' },
        { test: /\.css$/, use: isDevBuild ? ['style-loader', 'css-loader'] : ExtractTextPlugin.extract({ use: 'css-loader?minimize' }) },
        { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
        {
          test: /\.jsx?$/,
          exclude: /node_modules/,
          enforce: 'pre'
        },
        {
          test: /\.jsx?$/,
          exclude: /node_modules/,
          loader: 'babel-loader',
          query: {
            presets: ['react', 'es2015'],
            plugins: ['react-hot-loader/babel', "transform-object-rest-spread"]
          }
        },
        {
          test: /\.ico$/,
          loader: 'url-loader',
          query: { mimetype: 'image/x-icon' }
        }
      ]
    },
    plugins: [
      new CheckerPlugin(),
      new webpack.DllReferencePlugin({
        context: __dirname,
        manifest: require('./wwwroot/dist/vendor-manifest.json')
      })
    ].concat(isDevBuild ? [
      // Plugins that apply in development builds only
      new webpack.SourceMapDevToolPlugin({
        filename: '[file].map', // Remove this line if you prefer inline source maps
        moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
      })
    ] : [
        // Plugins that apply in production builds only
        new ExtractTextPlugin('site.css')
      ])
  }];
};