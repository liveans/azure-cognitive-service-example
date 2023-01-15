import React from "react";

interface ButtonProps {
    title: string;
    active?: boolean;
    onClick: () => void;
}

export const Button = ({title, active, onClick}: ButtonProps) => {
    return <button disabled={active} onClick={onClick} className={"text-white font-bold py-2 px-4 rounded " + (active === true ? "bg-blue-600" :"bg-green-500 hover:bg-green-700")}>
    {title}
  </button>
};