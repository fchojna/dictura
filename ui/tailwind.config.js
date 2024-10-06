/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  imporant: true,
  theme: {
    extend: {},
  },

  plugins: [
    require('@tailwindcss/forms'),
  ],
}

