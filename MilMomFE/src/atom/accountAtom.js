import { atom } from "recoil";
import { getAccountFS } from "../helper/helper";

export const accountAtom = atom({
    key:"account",
    default:getAccountFS()
})