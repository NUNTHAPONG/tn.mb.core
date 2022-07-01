const PROXY_CONFIG = [
  {
    context: ["/api/**"],
    target: "https://localhost:3000",
    changeOrigin: true,
    secure: false,
  },
];
module.exports = PROXY_CONFIG;
