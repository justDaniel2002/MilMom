import React, { memo } from "react";
import { footerContent1, footerContent2, footerData } from "../data/data";
import MilMomBtn from "./MilMomBtn";
import { Icon } from "@iconify/react/dist/iconify.js";
import logo from "../assets/logo.png";
import milmom from "../assets/milmom.png";

const Footer = () => {
  return (
    <div className="flex py-20 px-20 tracking-wide">
      <div className="w-1/5 text-wrap px-10">
        <div className="flex items-center">
          <img src={logo} className="w-1/4" />
          <img src={milmom} />
        </div>
        <div className="mb-3">{footerContent1}</div>
        <div>{footerContent2}</div>
      </div>
      <div className="w-3/5 flex">
        {footerData.map((section, index) => {
          const sectionTitle = Object.keys(section)[0];
          const sectionItems = section[sectionTitle];

          return (
            <div className="w-1/3 px-10" key={index}>
              <div className="font-bold mb-5">{sectionTitle}</div>

              {sectionItems.map((item, itemIndex) => (
                <div className="mb-3 font-medium" key={itemIndex}>
                  {item}
                </div>
              ))}
            </div>
          );
        })}
      </div>
      <div className="w-1/5 flex flex-col justify-center px-10">
        <div className="font-medium">
          <div className="mb-2">Liên hệ với chúng tôi tại đây</div>
          <div className="flex mb-3">
            <input
              className="w-2/3 rounded-l-lg bg-slate-950 px-3 py-2 text-neutral-500"
              placeholder="your email"
            />
            <MilMomBtn content="submit" className="rounded-r-lg" />
          </div>
          <div className="flex items-center text-3xl">
            <Icon icon="logos:facebook" className="mr-3" />
            <Icon icon="logos:twitter" className="mr-3"/>
            <Icon icon="skill-icons:instagram" className="mr-3"/>
            <Icon icon="skill-icons:linkedin" className="mr-3"/>
          </div>
        </div>
      </div>
    </div>
  );
}

export default memo(Footer)
