import React from 'react'
import Slider from "react-slick";


export default function SliderReact({images=[], onClickImg = () => {console.log("image click")}}) {
    
  return (
    <div className='relative flex overflow-x-scroll'>
      {images.map(img => <img onClick={() => onClickImg(img.image)} src={img.image} className='w-1/3 border mx-2'/>)}
    </div>
  )
}
