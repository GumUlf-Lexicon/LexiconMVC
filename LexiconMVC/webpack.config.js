/// <binding />
"use strict";

var path = require("path");
var WebpackNotifierPlugin = require("webpack-notifier");
var BrowserSyncPlugin = require("browser-sync-webpack-plugin");

module.exports = {
   entry: ['babel-polyfill', './React/index'],
   output: {
      path: path.resolve(__dirname, './wwwroot/React/'),
      filename: 'bundle.js'
   },
   module: {
      rules: [
         {
            test: /\.jsx?$/,
            exclude: /node_modules/,
            use: {
               loader: "babel-loader"
            }
         }
      ]
   },
   devtool: "inline-source-map",
   plugins: [new WebpackNotifierPlugin(), new BrowserSyncPlugin({ https: true })],
   resolve: {
      extensions: ['.js', '.jsx'],
   }
};