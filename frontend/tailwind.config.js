/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
  theme: {
    extend: {
      fontSize: {
        xs: "12pt",
        sm: "18pt",
        base: "21pt",
        lg: "24pt",
        xl: "36pt",
        "2xl": "60pt",
      },
      colors: {
        inherit: "inherit",
        current: "currentColor",
        transparent: "transparent",
        placeholder: "rgb(var(--color-placeholder) / <alpha-value>)",
        blue: "rgb(var(--color-blue) / <alpha-value>)",
        red: "#DD5555",
        grey: {
          DEFAULT: "rgb(var(--color-grey) / <alpha-value>)",
          light: "rgb(var(--color-light-grey) / <alpha-value>)",
          lightSecondary:
            "rgb(var(--color-light-secondary-grey) / <alpha-value>)",
          lightTertiary:
            "rgb(var(--color-light-tertiary-grey) / <alpha-value>)",
          dark: "rgb(var(--color-dark-grey) / <alpha-value>)",
        },
      },
      backgroundImage: {
        "screen-1-bg": "url('/screen1/Banner Photo.jpg')",
      },
      boxShadow: {
        card: "6px 6px 4px rgba(0, 0, 0, 0.2)",
        none: "none",
      },
      fontFamily: { sans: ["Helvetica Neue"] },
    },
  },
  plugins: [],
};
