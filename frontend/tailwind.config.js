/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend : {
      colors: {
        transparent: 'transparent',
        'fc24-black' : '#000000',
        'fc24': {
          100: '#282928',
          200: '#212222',
          300: '#171717',
          400: '#6f6f6a'
        },
        'fc24-accent': '#10f469',
      },
    }
  },
  plugins: [],
}