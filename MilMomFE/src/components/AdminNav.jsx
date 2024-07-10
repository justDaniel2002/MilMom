import React from "react";
import milmom from "../assets/milmom.png";
import { blankAvatar } from "../data/data";
import { Icon } from "@iconify/react/dist/iconify.js";
export default function AdminNav() {
  return (
    <div className="flex justify-between items-center p-3">
      <div className="flex items-end">
        <div className="flex font-medium text-3xl text-red-300"><span className="text-blue-950">Mil</span>Mom</div>
        <span className="font-bold text-neutral-600 tracking-wider"> , Welcome admin</span>
      </div>

      <div className="flex items-center">
        <Icon icon="mdi:bell-outline" />
        <img className="w-10 rounded-full ml-3" src={blankAvatar} />
      </div>
    </div>
  );
}
