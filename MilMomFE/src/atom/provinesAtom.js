import { atom } from "recoil";
import { getProvines } from "../helper/helper";

export const provinesAtom = atom({
    key:"provines",
    default: []
})