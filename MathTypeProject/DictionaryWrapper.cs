using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTypeProject
{
    class DictionaryWrapper
    {
        public Dictionary<char, string> unicodeToLatex = new Dictionary<char, string>();

        public DictionaryWrapper()
        {
            unicodeToLatex.Add('±', @"\pm ");
            unicodeToLatex.Add('∓', @"\mp ");
            unicodeToLatex.Add('×', @"\times ");
            unicodeToLatex.Add('÷', @"\div ");
            unicodeToLatex.Add('∝', @"\propto ");
            unicodeToLatex.Add('∕', @"/");
            unicodeToLatex.Add('*', @"\ast ");
            unicodeToLatex.Add('∘', @"\circ ");
            unicodeToLatex.Add('∙', @"\bullet ");
            unicodeToLatex.Add('⋅', @"\cdot ");
            unicodeToLatex.Add('∪', @"\cup ");
            unicodeToLatex.Add('∩', @"\cap ");
            unicodeToLatex.Add('⊎', @"\uplus ");
            unicodeToLatex.Add('⊓', @"\sqcap ");
            unicodeToLatex.Add('⊔', @"\sqcup ");
            unicodeToLatex.Add('∧', @"\wedge ");
            unicodeToLatex.Add('∨', @"\vee ");
            unicodeToLatex.Add('≮', @"PACKAMS\nless ");    //amssymb package
            unicodeToLatex.Add('≰', @"PACKAMS\nleq "); //amssymb package
            unicodeToLatex.Add('≯', @"PACKAMS\ngtr "); //amssymb package
            unicodeToLatex.Add('≱', @"PACKAMS\ngeq "); //amssymb package
            unicodeToLatex.Add('∼', @"\sim ");
            unicodeToLatex.Add('≃', @"\simeq ");
            unicodeToLatex.Add('≢', @"\not\equiv ");
            unicodeToLatex.Add('≄', @"\not\simeq ");
            unicodeToLatex.Add('≉', @"\not\approx ");
            unicodeToLatex.Add('≇', @"PACKAMS\ncong ");    //amssymb package
            unicodeToLatex.Add('∈', @"\in ");
            unicodeToLatex.Add('∋', @"\ni ");
            unicodeToLatex.Add('∉', @"\notin ");
            unicodeToLatex.Add('⊂', @"\subset ");
            unicodeToLatex.Add('⊃', @"\supset ");
            unicodeToLatex.Add('⊆', @"\subseteq ");
            unicodeToLatex.Add('⊇', @"\supseteq ");
            unicodeToLatex.Add('≺', @"\prec ");
            unicodeToLatex.Add('≻', @"\succ ");
            unicodeToLatex.Add('≼', @"\preceq ");
            unicodeToLatex.Add('≽', @"\succeq ");
            unicodeToLatex.Add('⊏', @"PACKAMS\sqsubset");  //amssymb package
            unicodeToLatex.Add('⊐', @"PACKAMS\sqsupset "); //amssymb package
            unicodeToLatex.Add('⊑', @"\sqsubseteq ");
            unicodeToLatex.Add('⊒', @"\sqsupseteq ");
            unicodeToLatex.Add('∥', @"\parallel ");
            unicodeToLatex.Add('⊥', @"\perp ");
            unicodeToLatex.Add('⊢', @"\vdash ");
            unicodeToLatex.Add('⊣', @"\dashv ");
            unicodeToLatex.Add('⋈', @"\bowtie ");
            unicodeToLatex.Add('≍', @"\asymp ");
            unicodeToLatex.Add('∑', @"\sum ");
            unicodeToLatex.Add('∫', @"\int ");
            unicodeToLatex.Add('∬', @"\iint "); //amsmath package
            unicodeToLatex.Add('∭', @"\iiint ");    //amsmath package
            unicodeToLatex.Add('∮', @"\oint ");
            unicodeToLatex.Add('∯', @"PACKINT\oiint ");    //esint package
            unicodeToLatex.Add('∰', @"PACKFDS\oiiint ");   //fdsymbol package
            unicodeToLatex.Add('∱', @"PACKSTX\intclockwise ");   //stix package
            unicodeToLatex.Add('∲', @"PACKINT\ointclockwise ");    //esint package
            unicodeToLatex.Add('∳', @"PACKINT\ointctrclockwise "); //esint package
            unicodeToLatex.Add('∏', @"\prod ");
            unicodeToLatex.Add('∐', @"\coprod ");
            unicodeToLatex.Add('⋂', @"\bigcap ");
            unicodeToLatex.Add('⋃', @"\bigcup ");
            unicodeToLatex.Add('⋀', @"\bigwedge ");
            unicodeToLatex.Add('⋁', @"\bigvee ");
            unicodeToLatex.Add('⨀', @"\bigodot ");
            unicodeToLatex.Add('⨂', @"\bigotimes ");
            unicodeToLatex.Add('⨁', @"\bigoplus ");
            unicodeToLatex.Add('⨄', @"\biguplus ");
            unicodeToLatex.Add('⨃', @"PACKFDS\bigcupdot ");    //fdsymbol package
            unicodeToLatex.Add('∔', @"PACKAMS\dotplus ");  //amssymb package
            unicodeToLatex.Add('∸', @"PACKFDS\dotminus "); //fdsymbol package
            unicodeToLatex.Add('∖', @"\setminus ");
            unicodeToLatex.Add('⋒', @"PACKAMS\Cap ");  //amssymb package
            unicodeToLatex.Add('⋓', @"PACKAMS\Cup ");  //amssymb package
            unicodeToLatex.Add('⊟', @"PACKAMS\boxminus "); //amssymb package
            unicodeToLatex.Add('⊠', @"PACKAMS\boxtimes "); //amssymb package
            unicodeToLatex.Add('⊡', @"PACKAMS\boxdot ");   //amssymb package
            unicodeToLatex.Add('⊞', @"PACKAMS\boxplus ");  //amssymb package
            unicodeToLatex.Add('⋇', @"PACKAMS\divideontimes ");    //amssymb package
            unicodeToLatex.Add('⋉', @"PACKAMS\ltimes ");   //amssymb package
            unicodeToLatex.Add('⋊', @"PACKAMS\rtimes ");   //amssymb package
            unicodeToLatex.Add('⋋', @"PACKAMS\leftthreetimes ");   //amssymb package
            unicodeToLatex.Add('⋌', @"PACKAMS\rightthreetimes");   //amssymb package
            unicodeToLatex.Add('⋏', @"PACKAMS\curlywedge ");   //amssymb package
            unicodeToLatex.Add('⋎', @"PACKAMS\curlyvee "); //amssymb package
            unicodeToLatex.Add('⊝', @"PACKAMS\circleddash ");  //amssymb package
            unicodeToLatex.Add('⊺', @"PACKAMS\intercal "); //amssymb package
            unicodeToLatex.Add('⊕', @"\oplus ");
            unicodeToLatex.Add('⊖', @"\ominus ");
            unicodeToLatex.Add('⊗', @"\otimes ");
            unicodeToLatex.Add('⊘', @"\oslash ");
            unicodeToLatex.Add('⊙', @"\odot ");
            unicodeToLatex.Add('⊛', @"PACKFDS\oast "); //fdsymbol package
            unicodeToLatex.Add('⊚', @"PACKAMS\circledcirc ");    //amssymb package
            unicodeToLatex.Add('†', @"\dag ");
            unicodeToLatex.Add('‡', @"\ddag ");
            unicodeToLatex.Add('⋆', @"\star ");
            unicodeToLatex.Add('⋄', @"\diamond ");
            unicodeToLatex.Add('≀', @"\wr ");
            unicodeToLatex.Add('△', @"\triangle ");
            unicodeToLatex.Add('⨅', @"PACKFDS\bigsqcap "); //fdsymbol package
            unicodeToLatex.Add('⨆', @"\bigsqcup ");
            unicodeToLatex.Add('∴', @"PACKAMS\therefore ");    //amssymb package
            unicodeToLatex.Add('∵', @"PACKAMS\because ");  //amssymb package
            unicodeToLatex.Add('⋘', @"PACKAMS\lll ");  //amssymb package
            unicodeToLatex.Add('⋙', @"PACKAMS\ggg ");  //amssymb package
            unicodeToLatex.Add('≦', @"PACKAMS\leqq "); //amssymb package
            unicodeToLatex.Add('≧', @"PACKAMS\geqq "); //amssymb package
            unicodeToLatex.Add('≲', @"PACKAMS\lesssim ");  //amssymb package
            unicodeToLatex.Add('≳', @"PACKAMS\gtrsim ");   //amssymb package
            unicodeToLatex.Add('⋖', @"PACKAMS\lessdot ");  //amssymb package
            unicodeToLatex.Add('⋗', @"PACKAMS\gtrdot ");   //amssymb package
            unicodeToLatex.Add('≶', @"PACKAMS\lessgtr ");  //amssymb package
            unicodeToLatex.Add('⋚', @"PACKAMS\lesseqgtr ");    //amssymb package
            unicodeToLatex.Add('≷', @"PACKAMS\gtrless ");  //amssymb package
            unicodeToLatex.Add('⋛', @"PACKAMS\gtreqless ");    //amssymb package
            unicodeToLatex.Add('≑', @"PACKAMS\doteqdot "); //amssymb package
            unicodeToLatex.Add('≒', @"PACKAMS\fallingdotseq ");    //amssymb package
            unicodeToLatex.Add('≓', @"PACKAMS\risingdotseq "); //amssymb package
            unicodeToLatex.Add('∽', @"PACKAMS\backsim ");  //amssymb package
            unicodeToLatex.Add('≊', @"PACKAMS\approxeq "); //amssymb package
            unicodeToLatex.Add('⋍', @"PACKAMS\backsimeq ");  //amssymb package  
            unicodeToLatex.Add('⋞', @"PACKAMS\curlyeqprec ");  //amssymb package
            unicodeToLatex.Add('⋟', @"PACKAMS\curlyeqsucc ");  //amssymb package
            unicodeToLatex.Add('≾', @"PACKAMS\precsim ");  //amssymb package
            unicodeToLatex.Add('≿', @"PACKAMS\succsim ");  //amssymb package
            unicodeToLatex.Add('⋜', @"PACKSTX\eqless ");   //stix package
            unicodeToLatex.Add('⋝', @"PACKSTX\eqgtr ");    //stix package
            unicodeToLatex.Add('⊲', @"PACKAMS\vartriangleleft ");  //amssymb package
            unicodeToLatex.Add('⊳', @"PACKAMS\vartriangleright "); //amssymb package
            unicodeToLatex.Add('⊴', @"PACKAMS\trianglelefteq ");   //amssymb package
            unicodeToLatex.Add('⊵', @"PACKAMS\trianglerighteq ");  //amssymb package
            unicodeToLatex.Add('⊨', @"\models ");
            unicodeToLatex.Add('⋐', @"PACKAMS\Subset ");   //amssymb package
            unicodeToLatex.Add('⋑', @"PACKAMS\Supset ");   //amssymb package
            unicodeToLatex.Add('⊩', @"PACKAMS\Vdash ");    //amssymb package
            unicodeToLatex.Add('⊪', @"PACKAMS\Vvdash ");   //amssymb package
            unicodeToLatex.Add('≖', @"PACKAMS\eqcirc ");   //amssymb package
            unicodeToLatex.Add('≗', @"PACKAMS\circeq ");   //amssymb package
            unicodeToLatex.Add('≜', @"PACKAMS\triangleq ");    //amssymb package
            unicodeToLatex.Add('≏', @"PACKAMS\bumpeq ");   //amssymb package
            unicodeToLatex.Add('≎', @"PACKAMS\Bumpeq ");   //amssymb package
            unicodeToLatex.Add('≬', @"PACKAMS\between ");  //amssymb package
            unicodeToLatex.Add('⋔', @"PACKAMS\pitchfork ");    //amssymb package
            unicodeToLatex.Add('≐', @"\doteq ");
            unicodeToLatex.Add('≪', @"PACKAMS\ll ");   //amssymb package
            unicodeToLatex.Add('≫', @"PACKAMS\gg ");   //amssymb package
            unicodeToLatex.Add('≤', @"PACKAMS\leq ");  //amssymb package
            unicodeToLatex.Add('≥', @"PACKAMS\geq ");  //amssymb package
            unicodeToLatex.Add('≅', @"\cong ");
            unicodeToLatex.Add('≈', @"\approx ");
            unicodeToLatex.Add('≡', @"\equiv ");
            unicodeToLatex.Add('∞', @"\infty ");
            unicodeToLatex.Add('≠', @"\neq ");

            unicodeToLatex.Add('∀', @"\forall ");
            unicodeToLatex.Add('∂', @"\partial ");
            unicodeToLatex.Add('ð', @"PACKAMS\eth ");  //amssymb package
            unicodeToLatex.Add('ℇ', @"PACKAMS\mathcal{E} ");   //amssymb package
            unicodeToLatex.Add('Ϝ', @"PACKSTX\digamma ");  //stix package
            unicodeToLatex.Add('Ⅎ', @"PACKSTX\Finv "); //stix package
            unicodeToLatex.Add('ℏ', @"\hbar");
            unicodeToLatex.Add('℩', @"PACKSTX\turnediota ");   //stix package
            unicodeToLatex.Add('ı', @"\imath ");
            unicodeToLatex.Add('I', @"PACKSTX\topbot ");   //stix package
            unicodeToLatex.Add('ϰ', @"PACKAMS\varkappa "); //amssymb package
            unicodeToLatex.Add('℘', @"\wp ");
            unicodeToLatex.Add('℧', @"PACKAMS\mho ");  //amssymb package
            unicodeToLatex.Add('Å', @"\AA ");
            unicodeToLatex.Add('℮', @"PACKTEX\textestimated ");    //textcomp package
            unicodeToLatex.Add('∃', @"\exists ");
            unicodeToLatex.Add('∄', @"PACKAMS\nexists ");  //amssymb package
            unicodeToLatex.Add('ℵ', @"\aleph ");
            unicodeToLatex.Add('ℶ', @"PACKAMS\beth "); //amssymb package
            unicodeToLatex.Add('ℷ', @"PACKAMS\gimel ");    //amssymb package
            unicodeToLatex.Add('ℸ', @"PACKAMS\daleth ");   //amssymb package

            unicodeToLatex.Add('√', @"\sqrt[]{}");
            unicodeToLatex.Add('∛', @"\cbrt{}");
            unicodeToLatex.Add('∜', @"\qdrt{}");
            unicodeToLatex.Add('/', @"\frac{}{}");
            unicodeToLatex.Add('⁄', @"\frac{}{}");
            unicodeToLatex.Add('□', "expect parenthesis");
            unicodeToLatex.Add('█', "expect big curly");
            unicodeToLatex.Add('■', "expect matrix");
            unicodeToLatex.Add('⁡', @" ");    //function control sign
            unicodeToLatex.Add('^', @"^{}");
            unicodeToLatex.Add('_', @"_{}");
            unicodeToLatex.Add('▒', "big operator separator");
            unicodeToLatex.Add('¦', @"{ \choose }");
            unicodeToLatex.Add('〖', @"(");
            unicodeToLatex.Add('〗', @")");
            unicodeToLatex.Add('┴', "text above");  //requires additional definitions
            unicodeToLatex.Add('┬', "text below");  //requires additional definitions
            unicodeToLatex.Add('┤', @"");
            unicodeToLatex.Add('≝', @"\overset{def}{=}");
            unicodeToLatex.Add('≞', @"\overset{m}{=}");
            unicodeToLatex.Add('{', @"\{");
            unicodeToLatex.Add('}', @"\}");
            unicodeToLatex.Add('〈', @"\langle ");
            unicodeToLatex.Add('〉', @"\rangle ");
            unicodeToLatex.Add('⌊', @"\lfloor ");
            unicodeToLatex.Add('⌋', @"\rfloor ");
            unicodeToLatex.Add('⌈', @"\lceil ");
            unicodeToLatex.Add('⌉', @"\rceil ");
            unicodeToLatex.Add('‖', @"\|");
            unicodeToLatex.Add('⟦', @"PACKFDS\lBrack ");   //fdsymbol package
            unicodeToLatex.Add('⟧', @"PACKFDS\rBrack ");   //fdsymbol package
            unicodeToLatex.Add('│', @"PACKFDS\vert ");   //fdsymbol package

            unicodeToLatex.Add('̇', @"\dot{}");
            unicodeToLatex.Add('̈', @"\ddot{}");
            unicodeToLatex.Add('⃛', @"\dddot{}");
            unicodeToLatex.Add('̂', @"\hat{}");
            unicodeToLatex.Add('̌', @"\check{}");
            unicodeToLatex.Add('́', @"\acute{}");
            unicodeToLatex.Add('̀', @"\grave{}");
            unicodeToLatex.Add('̆', @"\breve{}");
            unicodeToLatex.Add('̃', @"\tilde{}");
            unicodeToLatex.Add('̅', @"\bar{}");
            unicodeToLatex.Add('̿', @"\bar{\bar{}}");
            unicodeToLatex.Add('⏞', @"\overbrace{}");
            unicodeToLatex.Add('⏟', @"\brace{}");
            unicodeToLatex.Add('⃖', @"\overleftarrow{}");
            unicodeToLatex.Add('⃗', @"\vec{}");
            unicodeToLatex.Add('⃡', @"\overleftrightarrow{}");
            unicodeToLatex.Add('⃐', @"\overleftarrow{}");    //harpoon not supported
            unicodeToLatex.Add('⃑', @"\vec{}");    //harpoon not supported
            unicodeToLatex.Add('▭', @"PACKFRM");    //frame not supported - to frame the entire equation use framed package instead
            unicodeToLatex.Add('¯', @"\overline{}");
            unicodeToLatex.Add('▁', @"\underline{}");

            unicodeToLatex.Add('∅', @"\emptyset ");
            unicodeToLatex.Add('%', @"\% ");
            unicodeToLatex.Add('°', @"PACKGEN\degree ");   //gensymb package
            unicodeToLatex.Add('℉', @"^{\circ}F ");
            unicodeToLatex.Add('℃', @"^{\circ}C ");
            unicodeToLatex.Add('∆', @"PACKSTX\increment ");    //stix package
            unicodeToLatex.Add('∇', @"\nabla ");
            
            unicodeToLatex.Add('←', @"\leftarrow ");
            unicodeToLatex.Add('↑', @"\uparrow ");
            unicodeToLatex.Add('→', @"\rightarrow ");
            unicodeToLatex.Add('↓', @"\downarrow ");
            unicodeToLatex.Add('↔', @"\leftrightarrow ");
            unicodeToLatex.Add('↕', @"\updownarrow ");
            unicodeToLatex.Add('⇐', @"\Leftarrow ");
            unicodeToLatex.Add('⇒', @"\Rightarrow ");
            unicodeToLatex.Add('⇔', @"\Leftrightarrow ");
            unicodeToLatex.Add('⇕', @"\Updownarrow ");
            unicodeToLatex.Add('⟵', @"\longleftarrow ");
            unicodeToLatex.Add('⟶', @"\longrightarrow ");
            unicodeToLatex.Add('⟷', @"\longleftrightarrow ");
            unicodeToLatex.Add('⟸', @"\Longleftarrow ");
            unicodeToLatex.Add('⟹', @"\Longrightarrow ");
            unicodeToLatex.Add('⟺', @"\Longleftrightarrow ");
            unicodeToLatex.Add('↗', @"\nearrow ");
            unicodeToLatex.Add('↖', @"\nwarrow ");
            unicodeToLatex.Add('↘', @"\searrow ");
            unicodeToLatex.Add('↙', @"\swarrow ");
            unicodeToLatex.Add('↚', @"PACKAMS\nleftarrow ");   //amssymb package
            unicodeToLatex.Add('↛', @"PACKAMS\nrightarrow ");  //amssymb package
            unicodeToLatex.Add('↮', @"PACKAMS\nleftrightarrow ");  //amssymb package
            unicodeToLatex.Add('⇍', @"PACKAMS\nLeftarrow ");   //amssymb package
            unicodeToLatex.Add('⇏', @"PACKAMS\nRightarrow ");  //amssymb package
            unicodeToLatex.Add('⇎', @"PACKAMS\nLeftrightarrow ");  //amssymb package
            unicodeToLatex.Add('⇠', @"PACKAMS\dashleftarrow ");    //amssymb package
            unicodeToLatex.Add('⇢', @"PACKAMS\dashrightarrow ");   //amssymb package
            unicodeToLatex.Add('↤', @"PACKFDS\mapsfrom "); //fdsymbol package
            unicodeToLatex.Add('↦', @"\mapsto ");
            unicodeToLatex.Add('⟻', @"PACKFDS\longmapsfrom "); //fdsymbol package
            unicodeToLatex.Add('⟼', @"\longmapsto ");
            unicodeToLatex.Add('↩', @"\hookleftarrow ");
            unicodeToLatex.Add('↪', @"\hookrightarrow ");
            unicodeToLatex.Add('↼', @"\leftharpoonup ");
            unicodeToLatex.Add('↽', @"\leftharpoondown ");
            unicodeToLatex.Add('⇀', @"\rightharpoonup ");
            unicodeToLatex.Add('⇁', @"\rightharpoondown ");
            unicodeToLatex.Add('↿', @"PACKAMS\upharpoonleft ");    //amssymb package
            unicodeToLatex.Add('↾', @"PACKAMS\upharpoonright ");   //amssymb package
            unicodeToLatex.Add('⇃', @"PACKAMS\downharpoonleft ");  //amssymb package
            unicodeToLatex.Add('⇂', @"PACKAMS\downharpoonright "); //amssymb package
            unicodeToLatex.Add('⇋', @"PACKAMS\leftrightharpoons ");    //amssymb package
            unicodeToLatex.Add('⇌', @"\rightleftharpoons ");
            unicodeToLatex.Add('⇇', @"PACKAMS\leftleftarrows ");   //amssymb package
            unicodeToLatex.Add('⇉', @"PACKAMS\rightrightarrows "); //amssymb package
            unicodeToLatex.Add('⇈', @"PACKAMS\upuparrows ");   //amssymb package
            unicodeToLatex.Add('⇊', @"PACKAMS\downdownarrows ");   //amssymb package
            unicodeToLatex.Add('⇆', @"PACKAMS\leftrightarrows ");  //amssymb package
            unicodeToLatex.Add('⇄', @"PACKAMS\rightleftarrows ");  //amssymb package
            unicodeToLatex.Add('↫', @"PACKAMS\looparrowleft ");    //amssymb package
            unicodeToLatex.Add('↬', @"PACKAMS\looparrowright ");   //amssymb package
            unicodeToLatex.Add('↢', @"PACKAMS\leftarrowtail ");    //amssymb package
            unicodeToLatex.Add('↣', @"PACKAMS\rightarrowtail ");   //amssymb package
            unicodeToLatex.Add('↰', @"PACKAMS\Lsh ");  //amssymb package
            unicodeToLatex.Add('↱', @"PACKAMS\Rsh ");  //amssymb package
            unicodeToLatex.Add('↲', @"PACKFDS\Ldsh "); //fdsymbol package
            unicodeToLatex.Add('↳', @"PACKFDS\Rdsh "); //fdsymbol package
            unicodeToLatex.Add('⇚', @"PACKAMS\Lleftarrow ");   //amssymb package
            unicodeToLatex.Add('⇛', @"PACKAMS\Rrightarrow ");  //amssymb package
            unicodeToLatex.Add('↞', @"PACKAMS\twoheadleftarrow "); //amssymb package
            unicodeToLatex.Add('↠', @"PACKAMS\twoheadrightarrow ");    //amssymb package
            unicodeToLatex.Add('↶', @"PACKAMS\curvearrowleft ");   //amssymb package
            unicodeToLatex.Add('↷', @"PACKAMS\curvearrowright ");  //amssymb package
            unicodeToLatex.Add('↺', @"PACKAMS\circlearrowleft ");  //amssymb package
            unicodeToLatex.Add('↻', @"PACKAMS\circlearrowright "); //amssymb package
            unicodeToLatex.Add('⊸', @"PACKAMS\multimap "); //amssymb package
            unicodeToLatex.Add('↭', @"PACKFDS\leftrightwavearrow ");   //fdsymbol package
            unicodeToLatex.Add('↜', @"PACKFDS\leftwavearrow ");    //fdsymbol package
            unicodeToLatex.Add('↝', @"PACKFDS\rightwavearrow ");   //fdsymbol package
            unicodeToLatex.Add('⇜', @"PACKSTX\leftsquigarrow ");    //stix package
            unicodeToLatex.Add('⇝', @"PACKSTX\rightsquigarrow ");  //stix package

            unicodeToLatex.Add('⊈', @"PACKAMS\nsubseteq ");    //amssymb package
            unicodeToLatex.Add('⊉', @"PACKAMS\nsupseteq ");    //amssymb package
            unicodeToLatex.Add('⊊', @"PACKAMS\subsetneq ");    //amssymb package
            unicodeToLatex.Add('⊋', @"PACKAMS\supsetneq ");    //amssymb package
            unicodeToLatex.Add('⋢', @"PACKFDS\nsqsubseteq ");  //fdsymbol package
            unicodeToLatex.Add('⋣', @"PACKFDS\nsqsupseteq ");  //fdsymbol package
            unicodeToLatex.Add('⋦', @"PACKAMS\lnsim ");    //amssymb package
            unicodeToLatex.Add('⋧', @"PACKAMS\gnsim ");    //amssymb package
            unicodeToLatex.Add('⋨', @"PACKAMS\precnsim "); //amssymb package
            unicodeToLatex.Add('⋩', @"PACKAMS\succnsim "); //amssymb package
            unicodeToLatex.Add('⋪', @"PACKFDS\nlessclosed ");  //fdsymbol package
            unicodeToLatex.Add('⋫', @"PACKFDS\ngtrclosed ");   //fdsymbol package
            unicodeToLatex.Add('⋬', @"PACKFDS\nleqclosed ");   //fdsymbol package
            unicodeToLatex.Add('⋭', @"PACKFDS\ngeqclosed ");   //fdsymbol package
            unicodeToLatex.Add('∤', @"PACKAMS\nmid "); //amssymb package
            unicodeToLatex.Add('∦', @"PACKAMS\nparallel ");    //amssymb package
            unicodeToLatex.Add('⊬', @"PACKAMS\nvdash ");   //amssymb package
            unicodeToLatex.Add('⊭', @"PACKAMS\nvDash ");   //amssymb package
            unicodeToLatex.Add('⊮', @"PACKFDS\nrightVdash ");   //fdsymbol package
            unicodeToLatex.Add('⊯', @"PACKFDS\nrightVDash ");  //fdsymbol package
            unicodeToLatex.Add('≁', @"PACKAMS\nsim "); //amssymb package
            unicodeToLatex.Add('≭', @"PACKFDS\nasymp ");   //fdsymbol package
            unicodeToLatex.Add('≨', @"PACKAMS\lneqq ");    //amssymb package
            unicodeToLatex.Add('≩', @"PACKAMS\gneqq ");    //amssymb package
            unicodeToLatex.Add('⊀', @"PACKAMS\nprec ");    //amssymb package
            unicodeToLatex.Add('⊁', @"PACKAMS\nsucc ");    //amssymb package
            unicodeToLatex.Add('⋠', @"PACKFDS\npreccurlyeq "); //fdsymbol package
            unicodeToLatex.Add('⋡', @"PACKFDS\nsucccurlyeq "); //fdsymbol package
            unicodeToLatex.Add('∌', @"\notcontain ");
            unicodeToLatex.Add('⊄', @"PACKFDS\nsubset ");  //fdsymbol package
            unicodeToLatex.Add('⊅', @"PACKFDS\nsupset ");  //fdsymbol package

            unicodeToLatex.Add('¬', @"\neg ");

            unicodeToLatex.Add('α', @"\alpha ");
            unicodeToLatex.Add('β', @"\beta ");
            unicodeToLatex.Add('γ', @"\gamma ");
            unicodeToLatex.Add('δ', @"\delta ");
            unicodeToLatex.Add('ε', @"\varepsilon ");
            unicodeToLatex.Add('ϵ', @"\epsilon ");
            unicodeToLatex.Add('ζ', @"\zeta ");
            unicodeToLatex.Add('η', @"\eta ");
            unicodeToLatex.Add('θ', @"\theta ");
            unicodeToLatex.Add('ϑ', @"\vartheta ");
            unicodeToLatex.Add('ι', @"\iota ");
            unicodeToLatex.Add('κ', @"\kappa ");
            unicodeToLatex.Add('λ', @"\lambda ");
            unicodeToLatex.Add('μ', @"\mu ");
            unicodeToLatex.Add('ν', @"\nu ");
            unicodeToLatex.Add('ξ', @"\xi ");
            unicodeToLatex.Add('ο', @"o");
            unicodeToLatex.Add('π', @"\pi ");
            unicodeToLatex.Add('ϖ', @"\varpi ");
            unicodeToLatex.Add('ρ', @"\rho ");
            unicodeToLatex.Add('ϱ', @"\varrho ");
            unicodeToLatex.Add('σ', @"\sigma ");
            unicodeToLatex.Add('ς', @"\varsigma ");
            unicodeToLatex.Add('τ', @"\tau ");
            unicodeToLatex.Add('υ', @"\upsilon ");
            unicodeToLatex.Add('ϕ', @"\phi ");
            unicodeToLatex.Add('φ', @"\varphi ");
            unicodeToLatex.Add('χ', @"\chi ");
            unicodeToLatex.Add('ψ', @"\psi ");
            unicodeToLatex.Add('ω', @"\omega ");

            unicodeToLatex.Add('Α', @"A");
            unicodeToLatex.Add('Β', @"B");
            unicodeToLatex.Add('Γ', @"\Gamma ");
            unicodeToLatex.Add('Δ', @"\Delta ");
            unicodeToLatex.Add('Ε', @"E");
            unicodeToLatex.Add('Ζ', @"Z");
            unicodeToLatex.Add('Η', @"H");
            unicodeToLatex.Add('Θ', @"\Theta ");
            unicodeToLatex.Add('Ι', @"I");
            unicodeToLatex.Add('Κ', @"K");
            unicodeToLatex.Add('Λ', @"\Lambda ");
            unicodeToLatex.Add('Μ', @"M");
            unicodeToLatex.Add('Ν', @"N");
            unicodeToLatex.Add('Ξ', @"\Xi ");
            unicodeToLatex.Add('Ο', @"O");
            unicodeToLatex.Add('Π', @"\Pi ");
            unicodeToLatex.Add('Ρ', @"P");
            unicodeToLatex.Add('Σ', @"\Sigma ");
            unicodeToLatex.Add('Τ', @"T");
            unicodeToLatex.Add('Υ', @"\Upsilon ");
            unicodeToLatex.Add('Φ', @"\Phi ");
            unicodeToLatex.Add('Χ', @"X");
            unicodeToLatex.Add('Ψ', @"\Psi ");
            unicodeToLatex.Add('Ω', @"\Omega ");

            unicodeToLatex.Add('·', @"\cdot ");
            unicodeToLatex.Add('⋮', @"\vdots ");
            unicodeToLatex.Add('⋯', @"\cdots ");
            unicodeToLatex.Add('⋰', @"PACKFDS\udots ");    //fdsymbol package
            unicodeToLatex.Add('⋱', @"\ddots ");
            unicodeToLatex.Add('∎', @"PACKAMS\blacksquare ");   //amssymb package
            unicodeToLatex.Add('∟', @"PACKFDS\rightangle ");   //fdsymbol package
            unicodeToLatex.Add('∠', @"\angle ");
            unicodeToLatex.Add('∡', @"PACKAMS\measuredangle ");    //amssymb package
            unicodeToLatex.Add('∢', @"PACKAMS\sphericalangle ");   //amssymb package
            unicodeToLatex.Add('⊾', @"PACKFDS\measuredrightangle ");   //fdsymbol package
            unicodeToLatex.Add('⊿', @"PACKSTX\varlrtriangle ");    //stix package
            unicodeToLatex.Add('⋕', @"PACKSTX\equalparallel"); //stix package
            unicodeToLatex.Add('∶', @"PACKCOL\ratio ");    //colonequals package
            unicodeToLatex.Add('∷', @"PACKFDS\squaredots "); //fdsymbol package

            unicodeToLatex.Add('"', @"''");
        }
    }
}
