/** @type {import('tailwindcss').Config} */
module.exports = {
  presets: [require('@spartan-ng/ui-core/hlm-tailwind-preset')],
  content: [
    "./src/**/*.{html,ts}",
    './libs/**/*.{html,ts}',
  ],
  imporant: true,
  theme: {
    extend: {},
  },

  plugins: [
    require('@tailwindcss/forms'),
  ],
}

